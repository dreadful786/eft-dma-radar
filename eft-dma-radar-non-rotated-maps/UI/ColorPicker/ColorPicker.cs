using DarkModeForms;

namespace eft_dma_radar_non_rotated_maps.UI.ColorPicker
{
    public sealed partial class ColorPicker<TEnum, TClass> : Form
        where TEnum : Enum
        where TClass : ColorItem<TEnum>
    {
        private readonly Dictionary<TEnum, string> _colors;
        private readonly DarkModeCS _darkmode;
        private TEnum _selected;

        /// <summary>
        /// Form Result.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<TEnum, string> Result { get; private set; }

        public ColorPicker(string name, IDictionary<TEnum, string> existing)
        {
            _colors = new(existing);
            InitializeComponent();
            _darkmode = new DarkModeCS(this);
            PopulateOptions();
            if (comboBox_Colors.Items.Count > 0)
                comboBox_Colors.SelectedIndex = 0;
            this.Text = name;
        }

        /// <summary>
        /// Populate the ESP Color Options list.
        /// </summary>
        private void PopulateOptions()
        {

            var enumType = typeof(TEnum);

            foreach (var field in enumType.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var attributes = field.GetCustomAttributes(inherit: false);
                if (attributes?.Any(x => x is ObsoleteAttribute) ?? false)
                    continue;
                var value = (TEnum)field.GetValue(null)!;
                comboBox_Colors.Items.Add(ColorItem<TEnum>.CreateInstance(value));
            }
        }

        private void comboBox_Colors_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selected = ((TClass)comboBox_Colors.SelectedItem)!.Option;
            textBox_ColorValue.Text = _colors[_selected];
        }

        private void textBox_ColorValue_TextChanged(object sender, EventArgs e)
        {
            var input = textBox_ColorValue.Text.Trim();
            _colors[_selected] = input;

            try
            {
                // Convert the input color code to a Color object
                Color selectedColor = ColorTranslator.FromHtml(textBox_ColorValue.Text);

                // Apply the background color to match the entered color
                textBox_ColorValue.BackColor = selectedColor;

                // Determine text color based on luminance for contrast
                double luminance = (0.299 * selectedColor.R + 0.587 * selectedColor.G + 0.114 * selectedColor.B) / 255;

                // If luminance is low, use white text; otherwise, use black
                textBox_ColorValue.ForeColor = luminance < 0.5 ? Color.White : Color.Black;
            }
            catch
            {
                // If the input is invalid, reset to default colors
                textBox_ColorValue.BackColor = Color.White;
                textBox_ColorValue.ForeColor = Color.Black;
            }
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            var dlg = colorDialog1.ShowDialog();
            if (dlg is DialogResult.OK)
            {
                var color = colorDialog1.Color.ToSKColor();
                textBox_ColorValue.Text = color.ToString();
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            foreach (var color in _colors)
                if (!SKColor.TryParse(color.Value, out var skColor))
                    throw new Exception($"Invalid Color Value for {color.Key}!");
            this.Result = _colors;
            this.DialogResult = DialogResult.OK;
        }
    }
}