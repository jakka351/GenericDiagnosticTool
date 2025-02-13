using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassThruJ2534.lib.Forms
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }
        private async void TransitionToOrionForm()
        {
            // Disable user interaction during the transition
            this.Enabled = false;
            // Fade out the current form
            await FadeOut(this, 20);
            // Initialize the new form
            AlphaRomeoFifteen orionForm = new AlphaRomeoFifteen
            {
                Opacity = 0 // Start invisible
            };
            // Show the new form
            orionForm.Show();
            // Fade in the new form
            await FadeIn(orionForm, 20);
            // Close the current form after the new form is displayed
            
        }

        private async Task FadeOut(Form form, int duration)
        {
            while (form.Opacity > 0)
            {
                await Task.Delay(duration);
                form.Opacity -= 0.05;
            }
        }

        private async Task FadeIn(Form form, int duration)
        {
            while (form.Opacity < 1)
            {
                await Task.Delay(duration);
                form.Opacity += 0.05;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;
            if(progressBar1.Value == 99)
            {
                timer1.Enabled = false;
                Type currentType = this.GetType();
                MethodInfo methodInfo = currentType.GetMethod(
                    "TransitionToOrionForm",
                    BindingFlags.Instance | BindingFlags.NonPublic
                );
                if (methodInfo != null)
                {
                    methodInfo.Invoke(this, null);
                }
                return;
            }
        }
    }
}
