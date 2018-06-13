using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Spectare.ForHelper
{
    /// <summary>
    /// Логика взаимодействия для HelperMessageControl.xaml
    /// </summary>
    public partial class HelperMessageControl : UserControl
    {
        public HelperMessageControl()
        {
            InitializeComponent();
        }
        public class MainViewModel
        {
            public MainViewModel()
            {
                Messages = new List<MessageBase>()
            {
                new MyMessage("Детка, ты ревнуешь?"),
                new CustomMessage("Нет"),
                new MyMessage("Детка, ты ревнуешь?"),
                new CustomMessage("Нет"),
                new MyMessage("Детка, ты ревнуешь?"),
                new CustomMessage("Я же сказал, нет"),
                new MyMessage("Дальше много букав -_-"),
            };
            }

            public List<MessageBase> Messages { get; private set; }
            public abstract class MessageBase
            {
                protected MessageBase(string text)
                {
                    Text = text;
                }

                public virtual string Text { get; protected set; }
            }

            public class MyMessage : MessageBase
            {
                public MyMessage(string text)
                    : base(text) { }
            }

            public class CustomMessage : MessageBase
            {
                public CustomMessage(string text)
                    : base(text) { }
            }
        }
    }
}
