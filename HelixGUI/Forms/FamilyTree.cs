using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Helix;
using System.Windows.Forms;

namespace HelixGUI
{
    /// <summary>
    /// FamilyTree reads a database and produces a TreeView of all people's heritage.
    /// </summary>
    public partial class FamilyTree : Form
    {
        public FamilyTree()
        {
            InitializeComponent();
        }

        private void FamilyTree_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Load a database into the tree
        /// </summary>
        /// <param name="database">Simulation database</param>
        public void LoadDataSource(SQLiteDatabase database)
        {
            //
        }
    }
}
