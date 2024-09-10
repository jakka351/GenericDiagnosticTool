// /////////////////////////////////////////////////////////////////////////////
//   ________                           .__                          
//  /  _____/  ____   ____   ___________|__| ____                    
// /   \  ____/ __ \ /    \_/ __ \_  __ \  |/ ___\                   
// \    \_\  \  ___/|   |  \  ___/|  | \/  \  \___                   
//  \______  /\___  >___|  /\___  >__|  |__|\___  >                  
//         \/     \/     \/     \/              \/                   
// ________  .__                                      __  .__        
// \______ \ |__|____     ____   ____   ____  _______/  |_|__| ____  
//  |    |  \|  \__  \   / ___\ /    \ /  _ \/  ___/\   __\  |/ ___\ 
//  |    `   \  |/ __ \_/ /_/  >   |  (  <_> )___ \  |  | |  \  \___ 
// /_______  /__(____  /\___  /|___|  /\____/____  > |__| |__|\___  >
//         \/        \//_____/      \/           \/               \/  //Version 1.0.0
// 

using System;
using System.Windows.Forms;

namespace PassThruJ2534
{
	// Token: 0x02000006 RID: 6
	internal static class Program
	{
		// Token: 0x06000031 RID: 49 RVA: 0x000046D6 File Offset: 0x000028D6
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new PassThru());
		}
	}
}
