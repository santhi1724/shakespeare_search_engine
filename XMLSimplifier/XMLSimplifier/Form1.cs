using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace XMLSimplifier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSimplify_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            if (!string.IsNullOrEmpty(txtFileURL.Text))
            {
                // looping thorugh all the file sof xml type from the folder selected
                foreach (string file in Directory.EnumerateFiles(txtFileURL.Text, "*.xml"))
                {
                   string fileURL = file;
                    if (!string.IsNullOrEmpty(txtFileURL.Text))
                    {
                       
                        try
                        {
                            string xml = File.ReadAllText(fileURL);
                            //xml reader setting 
                            XmlReaderSettings settings = new XmlReaderSettings();
                            settings.DtdProcessing = DtdProcessing.Ignore;
                            XmlReader rdr = XmlReader.Create(new System.IO.StringReader(xml), settings);
                            int countTitle = 0;

                            XmlDocument doc = new XmlDocument();
                           // adding the node- add
                            XmlNode addNode = doc.CreateElement("add");
                            doc.AppendChild(addNode);
                            // adding the node- doc
                            XmlNode docNode = doc.CreateElement("doc");
                            addNode.AppendChild(docNode);
                            while (rdr.Read())
                            {
                                // checking for node type element
                                // the logic inside this if loop takes care of screening only first Title and all the line elements in the plays.
                                if (rdr.NodeType == XmlNodeType.Element)
                                {
                                    // Filterinf the first Title
                                    if (rdr.LocalName.ToUpper() == "TITLE" && countTitle == 0)
                                    {
                                        // Console.WriteLine(rdr.LocalName);
                                        XmlNode titleField = doc.CreateElement("field");
                                        XmlAttribute name = doc.CreateAttribute("name");
                                        name.Value = "id";
                                        titleField.Attributes.Append(name);
                                        titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                                        docNode.AppendChild(titleField);
                                        countTitle = 1;
                                    }
                                    // Filterinf the lines or dialogues in the plays
                                    if (rdr.LocalName.ToUpper() == "LINE")
                                    {
                                        // Console.WriteLine(rdr.LocalName);
                                        XmlNode titleField = doc.CreateElement("field");
                                        XmlAttribute name = doc.CreateAttribute("name");
                                        name.Value = "text";
                                        titleField.Attributes.Append(name);
                                        titleField.AppendChild(doc.CreateTextNode(rdr.ReadInnerXml()));
                                        docNode.AppendChild(titleField);
                                    }
                                }

                            }
                            // creatig the folder 'simplified' if it doenst exist and saving all the simplified documents to this folder
                            string path = Path.GetDirectoryName(fileURL);

                            string fileName = Path.GetFileNameWithoutExtension(fileURL);
                            if (!System.IO.Directory.Exists(path + "//" + "simplified"))
                            {
                                System.IO.Directory.CreateDirectory(path + "//" + "simplified");

                                doc.Save(path + "//" + "simplified" + "//" + fileName + ".xml");

                            }
                            else {
                                doc.Save(path + "//" + "simplified" + "//" + fileName + ".xml");
                            }
                            lblError.Text = "Document Convereted Successfully !";
                            lblError.ForeColor = System.Drawing.Color.Green;
                        }
                        //hadling exceptions while performing the above task
                        catch (Exception ex)
                        {
                            lblError.Text = "Action Unsucessfull ! Please try again later.";
                            lblError.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            else {
                lblError.Text = "Please select a folder.";
                lblError.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            // folder select option dialog box
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string file= folderBrowserDialog1.SelectedPath;
                txtFileURL.Text = folderBrowserDialog1.SelectedPath;
                try
                {
                    txtFileURL.Text = file;
                }
                catch
                {

                    lblError.Text = "Action Unsucessfull ! Please try again later.";
                    lblError.ForeColor = System.Drawing.Color.Red;
                }
            }

            }
    }
}
