using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FontGlyphExporter
{
    public partial class MainForm : Form
    {
        private string fontPath = "";
        private string cssPath = "";
        private List<IconInfo> allIcons = new();
        private List<IconInfo> selectedIcons = new();
        private PrivateFontCollection fontCollection = new();
        private Font font;
        private Dictionary<string, string> regexPatterns = new();
        private List<int> selectedSizes = new();

        public MainForm()
        {
            InitializeComponent();
            InitializeRegexPatterns();
            InitializeSizeCheckboxes();
            cboRegexPattern.SelectedIndex = 0;
        }

        private void InitializeRegexPatterns()
        {
            regexPatterns.Add("Font Awesome 5/6", @"\.fa-([a-z0-9-]+)\s*{[^}]*--fa:\s*""\\(f[a-f0-9]{3,4})""");
            regexPatterns.Add("Font Awesome 4", @"\.fa-([a-z0-9-]+):before\s*{[^}]*content:\s*""\\(f[a-f0-9]{3,4})""");
            regexPatterns.Add("Material Icons", @"\.material-icons-([a-z0-9-]+):before\s*{[^}]*content:\s*""\\(e[a-f0-9]{3,4})""");
            regexPatterns.Add("Custom", "");
        }

        private void InitializeSizeCheckboxes()
        {
            chkSize4.Tag = 4;
            chkSize8.Tag = 8;
            chkSize12.Tag = 12;
            chkSize24.Tag = 24;

            // Default selection
            chkSize12.Checked = true;
            chkSize24.Checked = true;
            UpdateSelectedSizes();
        }

        private void UpdateSelectedSizes()
        {
            selectedSizes.Clear();

            foreach (Control c in pnlSizes.Controls)
            {
                if (c is CheckBox chk && chk.Checked && chk.Tag is int size)
                {
                    selectedSizes.Add(size);
                }
            }

            // Update the selected sizes label
            lblSelectedSizes.Text = selectedSizes.Count > 0
                ? $"Selected sizes: {string.Join(", ", selectedSizes)}px"
                : "No sizes selected";
        }

        private void btnBrowseTTF_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new() { Filter = "Font Files (*.ttf)|*.ttf" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fontPath = ofd.FileName;
                txtTTF.Text = fontPath;
            }
        }

        private void btnBrowseCSS_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new() { Filter = "CSS Files (*.css)|*.css" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                cssPath = ofd.FileName;
                txtCSS.Text = cssPath;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!File.Exists(fontPath) || !File.Exists(cssPath))
            {
                MessageBox.Show("Please select valid CSS and TTF files.");
                return;
            }

            fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile(fontPath);
            font = new Font(fontCollection.Families[0], 16);

            string css = File.ReadAllText(cssPath);
            string patternToUse;

            if (cboRegexPattern.SelectedItem.ToString() == "Custom")
            {
                patternToUse = txtCustomRegex.Text;
                if (string.IsNullOrWhiteSpace(patternToUse))
                {
                    MessageBox.Show("Please enter a valid regex pattern.");
                    return;
                }
            }
            else
            {
                patternToUse = regexPatterns[cboRegexPattern.SelectedItem.ToString()];
            }

            try
            {
                var matches = Regex.Matches(css, patternToUse, RegexOptions.IgnoreCase);

                allIcons.Clear();
                foreach (Match match in matches)
                {
                    if (match.Groups.Count < 3) continue;
                    string name = match.Groups[1].Value;
                    string unicode = match.Groups[2].Value;
                    allIcons.Add(new IconInfo { name = name, unicode = unicode });
                }

                if (allIcons.Count == 0)
                {
                    MessageBox.Show("No icons found with the selected pattern. Try a different pattern or check your CSS file.");
                    return;
                }

                PopulateGrid();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Invalid regex pattern: {ex.Message}");
            }
        }

        private void PopulateGrid()
        {
            iconFlowPanel.Controls.Clear();
            selectedIcons.Clear();
            UpdateCounter();

            foreach (var icon in allIcons)
            {
                var panel = new Panel
                {
                    Width = 80,
                    Height = 100,
                    Margin = new Padding(5),
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = icon
                };

                var bmp = new Bitmap(48, 48);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                    string glyph = char.ConvertFromUtf32(Convert.ToInt32(icon.unicode, 16));
                    g.DrawString(glyph, font, Brushes.Black, 0, 0);
                }

                var pic = new PictureBox
                {
                    Image = bmp,
                    SizeMode = PictureBoxSizeMode.CenterImage,
                    Width = 48,
                    Height = 48,
                    Top = 5,
                    Left = 15
                };

                var lbl = new Label
                {
                    Text = icon.name,
                    Width = 70,
                    Top = 60,
                    Left = 5,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                panel.Controls.Add(pic);
                panel.Controls.Add(lbl);

                panel.Click += (s, e) =>
                {
                    if (selectedIcons.Contains(icon))
                    {
                        selectedIcons.Remove(icon);
                        panel.BackColor = SystemColors.Control;
                    }
                    else
                    {
                        selectedIcons.Add(icon);
                        panel.BackColor = Color.LightBlue;
                    }
                    UpdateCounter();
                };

                iconFlowPanel.Controls.Add(panel);
            }
        }

        private void UpdateCounter()
        {
            lblCounter.Text = $"Selected: {selectedIcons.Count} / {allIcons.Count}";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (selectedIcons.Count == 0)
            {
                MessageBox.Show("Please select at least one icon to export.");
                return;
            }

            if (selectedSizes.Count == 0)
            {
                MessageBox.Show("Please select at least one size for export.");
                return;
            }

            var icons = new List<object>();
            var outputDir = Path.Combine("output", "icons");
            Directory.CreateDirectory(outputDir);

            foreach (var icon in selectedIcons)
            {
                foreach (var size in selectedSizes)
                {
                    string glyph = char.ConvertFromUtf32(Convert.ToInt32(icon.unicode, 16));
                    string file = $"icon_{icon.name}_{size}x{size}.bin";
                    string path = Path.Combine(outputDir, file);

                    using Bitmap bmp = new(size, size);
                    using Graphics g = Graphics.FromImage(bmp);
                    g.Clear(Color.White);
                    g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                    g.DrawString(glyph, new Font(font.FontFamily, size), Brushes.Black, 0, 0);

                    using FileStream fs = new(path, FileMode.Create);
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        for (int x = 0; x < bmp.Width; x += 8)
                        {
                            byte b = 0;
                            for (int bit = 0; bit < 8 && (x + bit) < bmp.Width; bit++)
                            {
                                var pixel = bmp.GetPixel(x + bit, y);
                                if (pixel.R < 128) b |= (byte)(1 << bit);
                            }
                            fs.WriteByte(b);
                        }
                    }

                    icons.Add(new { name = icon.name, file = file, width = size, height = size });
                }
            }

            File.WriteAllText("output/icons_index.json", JsonSerializer.Serialize(icons, new JsonSerializerOptions { WriteIndented = true }));
            MessageBox.Show("Export complete!");
        }

        private void cboRegexPattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isCustom = cboRegexPattern.SelectedItem.ToString() == "Custom";
            txtCustomRegex.Visible = isCustom;
            lblCustomRegex.Visible = isCustom;
        }

        private void sizeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSelectedSizes();
        }

        public class IconInfo
        {
            public string name { get; set; }
            public string unicode { get; set; }
        }
    }
}