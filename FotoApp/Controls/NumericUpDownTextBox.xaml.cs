using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using WPFControlTest;

// From http://www.codeproject.com/Articles/124183/Numeric-Up-Down-Textbox-that-Inherits-from-TextBox
// Modified by Glenn Rowe to fix the bug where a number entered directly into the TextBox doesn't translate to a Value.
namespace FotoApp.Controls
{
    /// <summary>
    /// Interaction logic for NumericUpDownTextBox.xaml
    /// </summary>    
    public partial class NumericUpDownTextBox :TextBox
    {
        #region Private Members
        private VisualCollection controls;
        private Button upButton;
        private Button downButton;
        private ButtonsProperties ButtonsViewModel;

        /// <summary>
        /// Set to indicate if the Buttons are displayed.
        /// The buttons are not displayed if the width to height 
        /// ratio of the control is less than a certain value
        /// </summary>
        private bool showButtons = true;
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor: initializes the TextBox, creates the buttons,
        /// and attaches event handlers for the buttons and TextBox
        /// </summary>
        public NumericUpDownTextBox()
        {
            InitializeComponent();
            var buttons = new ButtonsProperties(this);
            ButtonsViewModel = buttons;

            // Create buttons
            upButton = new Button()
            {
                Cursor = Cursors.Arrow,
                DataContext = buttons,
                Tag = true
            };
            upButton.Click += upButton_Click;

            downButton = new Button()
            {
                Cursor = Cursors.Arrow,
                DataContext = buttons,
                Tag = false
            };
            downButton.Click += downButton_Click;

            // Create control collections
            controls = new VisualCollection(this);
            controls.Add(upButton);
            controls.Add(downButton);

            //Hook up text event handlers
            PreviewTextInput += control_PreviewTextInput;
            PreviewKeyDown += control_PreviewKeyDown;
            LostFocus += control_LostFocus;
            MouseWheel += Control_MouseWheel;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Paint methods

        /// <summary>
        /// Called to arrange and size the content of a 
        ///         System.Windows.Controls.Control object.
        /// </summary>
        /// <param name="arrangeSize">The computed size that is used to 
        ///                 arrange the content</param>
        /// <returns>The size of the control</returns>
        protected override Size ArrangeOverride(Size arrangeSize)
        {
            double height = arrangeSize.Height;
            double width = arrangeSize.Width;
            showButtons = width > 1.5 * height;

            if (showButtons)
            {
                double buttonWidth = 3 * height / 4;
                Size buttonSize = new Size(buttonWidth, height / 2);
                Size textBoxSize = new Size(width - buttonWidth, height);
                double buttonsLeft = width - buttonWidth;
                Rect upButtonRect = new Rect(new 
                    Point(buttonsLeft, 0), buttonSize);
                Rect downButtonRect = new Rect(new 
                    Point(buttonsLeft, height / 2), buttonSize);
                base.ArrangeOverride(textBoxSize);

                upButton.Arrange(upButtonRect);
                downButton.Arrange(downButtonRect);
                return arrangeSize;
            }
            else
            {
                return base.ArrangeOverride(arrangeSize);
            }
        }

        /// <summary>
        /// Overrides System.Windows.Media.Visual.GetVisualChild(System.Int32), and returns
        //     a child at the specified index from a collection of child elements.
        /// </summary>
        /// <param name="index">The zero-based index of the requested child element in the collection.</param>
        /// <returns>The requested child element.</returns>
        protected override Visual GetVisualChild(int index)
        {
            if (index < base.VisualChildrenCount)
                return base.GetVisualChild(index);
            return controls[index - base.VisualChildrenCount];
        }

        /// <summary>
        /// Gets the number of visual child elements within this element.
        /// </summary>
        protected override int VisualChildrenCount
        {
            get
            {
                if (showButtons)
                    return controls.Count + base.VisualChildrenCount;
                else
                    return base.VisualChildrenCount;
            }
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles up button click (ie increment TextBox value)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upButton_Click(object sender, RoutedEventArgs e)
        {
            Add(1);
        }

        /// <summary>
        /// Handles the down button click (ie decrement TextBox value)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void downButton_Click(object sender, RoutedEventArgs e)
        {
            Add(-1);
        }

        /// <summary>
        /// Ensures that keypress is a valid character (numeric or negative sign)
        /// - negative sign ('-') only allowed if Minimum value less than 0, the entry 
        ///     is at the beginning of the text and there is not already a negative sign
        /// - number only allowed if not beginning of text and there is a negative sign
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Contains arguments associated with changes to
        ///                          a System.Windows.Input.TextComposition</param>
        private void control_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Catch any non-numeric keys
            if ("0123456789".IndexOf(e.Text) < 0)
            {
                // else check for negative sign
                if (e.Text == "-" && MinValue < 0)
                {
                    if (Text.Length == 0 || (CaretIndex == 0 &&
                                    Text[0] != '-'))
                    {
                        e.Handled = false;
                        return;
                    }
                }
                e.Handled = true;
            }
            else // A digit has been pressed
            {
                // We now know that have good value: check for attempting to put number before '-'
                if (Text.Length > 0 && CaretIndex == 0 &&
                    Text[0] == '-' && SelectionLength == 0)
                {
                    // Can't put number before '-'
                    e.Handled = true;
                }
                else
                {
                    // check for what new value will be:
                    StringBuilder sb = new StringBuilder(Text);
                    sb.Remove(CaretIndex, SelectionLength);
                    sb.Insert(CaretIndex, e.Text);
                    int newValue = int.Parse(sb.ToString());
                    // check if beyond allowed values
                    if (FixValueKeyPress(newValue))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        /// <summary>
        /// Checks if the keypress is the up or down key, and then handles keyboard input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void control_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                HandleModifiers(-1);
                e.Handled = true;
            }
            else if (e.Key == Key.Up)
            {
                HandleModifiers(1);
                e.Handled = true;
            }
            // Space key is not caught by PreviewTextInput
            else if (e.Key == Key.Space)
                e.Handled = true;
            else
                e.Handled = false;
        }

        private void control_LostFocus(object sender, RoutedEventArgs e)
        {
            FixValue();
        }

        void Control_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Add(e.Delta);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Checks if any of the Keyboard modifier keys are pressed that might 
        /// affect the change in the value of the TextBox.
        /// In this case only the shift key affects the value
        /// </summary>
        /// <param name="value">Integer value to modify</param>
        private void HandleModifiers(int value)
        {
            if (Keyboard.Modifiers == ModifierKeys.Shift) value *= 10;
            Add(value);
        }

        /// <summary>
        /// Add specified value the TextBox, fixing value
        /// if less than Minimum or greater than manimum
        /// </summary>
        /// <param name="value">Interger to add to TextBox value</param>
        private void Add(int value)
        {
            int currentValue;
            if (int.TryParse(Text, out currentValue))
            {
                currentValue += value;
                if (FixValue(currentValue))
                    UpdateText(currentValue);
            }
            else if (string.IsNullOrWhiteSpace(Text) && value != 0)
            {
                if (FixValue(value))
                    UpdateText(value);
            }
        }

        /// <summary>
        /// Only does something if the Textbox contains an out of range number
        /// </summary>
        private void FixValue()
        {
            int value;
            if (int.TryParse(Text, out value))
            {
                FixValue(value);
            }
            //not a number--what to do
        }

        /// <summary>
        /// This only does something if the value is out of range
        /// (ie above maximum or below minimum allowed values
        /// </summary>
        /// <param name="value">interger to check against limits</param>
        /// <returns></returns>
        private bool FixValue(int value)
        {
            if (value > MaxValue)
            {
                UpdateText(MaxValue);
                return false;
            }
            else if (value < MinValue)
            {
                UpdateText(MinValue);
                return false;
            }
            // else: nothing to fix
            return true;
        }

        /// <summary>
        /// Will fix value only if the value is beyond what could be
        /// a valid entry given more characters could be added to TextBox
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool FixValueKeyPress(int value)
        {
            //Want to allow user to build a number with keystrokes
            if (value > MaxValue && MaxValue > 0)
            {
                UpdateText(MaxValue);
                return false;
            }
            else if (value < MinValue && MinValue < 0)
            {
                UpdateText(MinValue);
                return false;
            }
            // else: nothing to fix
            return true;
        }

        private void UpdateText(int value)
        {
            Text = value.ToString();
            CaretIndex = Text.Length;
            Value = value;
        }
        #endregion

        #region Dependency Properties
        public int MaxValue
        {
            get { return (int)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(int), typeof(NumericUpDownTextBox), new UIPropertyMetadata(int.MaxValue));

        public int MinValue
        {
            get { return (int)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(int), typeof(NumericUpDownTextBox), new UIPropertyMetadata(0));

        /// <summary>
        /// TextBox Text value converted to an integer
        /// </summary>
        public int Value
        {
            get 
            {
              // Added so that Value matches the text in the text box.
              Value = int.Parse(Text);
              return (int)GetValue(ValueProperty); 
            }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDownTextBox),
            new UIPropertyMetadata(0, new PropertyChangedCallback(ValueChangedCallback)));

        private static void ValueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as NumericUpDownTextBox;
            control.ValueChangedCallback((int)e.OldValue, (int)e.NewValue);
        }

        private void ValueChangedCallback(int oldValue, int newValue)
        {
            Text = newValue.ToString();
        }

        private void MaxValueChangedCallback(int oldValue, int newValue)
        {
            FixValue();
        }

        private void MinValueChangedCallback(int oldValue, int newValue)
        {
            FixValue();
        }
        #endregion

        #region Button dependency properties
        /// <summary>
        /// Button Background Brush
        /// </summary>
        public Brush ButtonBackground
        {
            get { return (Brush)GetValue(ButtonBackgroundProperty); }
            set { SetValue(ButtonBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonBackgroundProperty =
            DependencyProperty.Register("ButtonBackground", typeof(Brush), typeof(NumericUpDownTextBox),
            new UIPropertyMetadata(null, ButtonPropertyChangedCallback));

        public Brush ButtonForeground
        {
            get { return (Brush)GetValue(ButtonForegroundProperty); }
            set { SetValue(ButtonForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonForegroundProperty =
            DependencyProperty.Register("ButtonForeground", typeof(Brush), typeof(NumericUpDownTextBox),
            new UIPropertyMetadata(null, ButtonPropertyChangedCallback));

        /// <summary>
        /// Button Background Brush when button IsPressed
        /// </summary>
        public Brush ButtonPressedBackground
        {
            get { return (Brush)GetValue(ButtonPressedBackgroundProperty); }
            set { SetValue(ButtonPressedBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonPressedBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonPressedBackgroundProperty =
            DependencyProperty.Register("ButtonPressedBackground", typeof(Brush), typeof(NumericUpDownTextBox),
            new UIPropertyMetadata(null, ButtonPropertyChangedCallback));

        /// <summary>
        /// Button Background when mouse is over button
        /// </summary>
        public Brush ButtonMouseOverBackground
        {
            get { return (Brush)GetValue(ButtonMouseOverBackgroundProperty); }
            set { SetValue(ButtonMouseOverBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonMouseOverBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonMouseOverBackgroundProperty =
            DependencyProperty.Register("ButtonMouseOverBackground", typeof(Brush), typeof(NumericUpDownTextBox),
            new UIPropertyMetadata(null, ButtonPropertyChangedCallback));

        /// <summary>
        /// Button Border Brush
        /// </summary>
        public Brush ButtonBorderBrush
        {
            get { return (Brush)GetValue(ButtonBorderBrushProperty); }
            set { SetValue(ButtonBorderBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonBorderBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonBorderBrushProperty =
            DependencyProperty.Register("ButtonBorderBrush", typeof(Brush), typeof(NumericUpDownTextBox),
            new UIPropertyMetadata(null, ButtonPropertyChangedCallback));

        /// <summary>
        /// Button Border Thickness
        /// </summary>
        public Thickness? ButtonBorderThickness
        {
            get { return (Thickness?)GetValue(ButtonBorderThicknessProperty); }
            set { SetValue(ButtonBorderThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonBorderThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonBorderThicknessProperty =
            DependencyProperty.Register("ButtonBorderThickness", typeof(Thickness?), typeof(NumericUpDownTextBox),
            new UIPropertyMetadata(null, ButtonPropertyChangedCallback));

        /// <summary>
        /// Button Border Thickness
        /// </summary>
        public CornerRadius? ButtonCornerRadius
        {
            get { return (CornerRadius?)GetValue(ButtonCornerRadiusProperty); }
            set { SetValue(ButtonCornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonBorderThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonCornerRadiusProperty =
            DependencyProperty.Register("ButtonCornerRadiusThickness", typeof(CornerRadius?), typeof(NumericUpDownTextBox),
            new UIPropertyMetadata(null, ButtonPropertyChangedCallback));

        private static void ButtonPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NumericUpDownTextBox target = (NumericUpDownTextBox)d;
            target.ButtonsViewModel.NotifyPropertyChanged(e.Property.ToString());
        }
        #endregion
    }
}