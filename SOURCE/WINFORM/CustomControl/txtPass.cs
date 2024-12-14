using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl
{
    public class txtPass:TextBox
    {
        public txtPass()
        {
            this.PasswordChar = '*';
            this.UseSystemPasswordChar = true;

            this.KeyPress+=TxtPass_KeyPress;
        }

        private void TxtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '\b')  // '\b' cho phép phím Backspace
            {
                e.Handled = true;  // Nếu ký tự không hợp lệ, ngừng xử lý
            }
        }
    }
}
