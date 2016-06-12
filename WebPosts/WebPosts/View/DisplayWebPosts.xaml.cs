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
using WebPosts.ViewModel;

namespace WebPosts.View
{
    /// <summary>
    /// Interaction logic for DisplayWebPosts.xaml
    /// </summary>
    public partial class DisplayWebPosts : Window
    {
        public DisplayWebPosts()
        {
            InitializeComponent();
            this.DataContext = new DisplayWebpostsVM();
        }
    }
}
