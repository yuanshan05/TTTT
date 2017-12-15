using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace MaterialEWpfDemo
{
    public class FocusBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.TextChanged += TextChangedEvent;
        }

        private void TextChangedEvent(object sender, TextChangedEventArgs e)
        {
            if (e.OriginalSource is TextBox text)
            {
                text.SelectionStart = text.Text.Length;
            }
        }
    }

    public class TextChangedBehavior : Behavior<ComboBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.PreviewTextInput += TextInput;
            this.AssociatedObject.SelectionChanged += SelectionChanged;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if(e.OriginalSource is )
        }

        private void TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (e.OriginalSource is TextBox txt)
            {
                txt.SelectionStart = txt.Text.Length;
                Console.WriteLine(txt.Text.Length);
            }
        }
    }
}
