using System.Xml;

namespace consolexml2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string tmpfile = "C:\\Users\\seppe.landtsheer\\source\\repos\\consolexml2\\consolexml2\\tmp.xml";
            TextWriter t = File.CreateText(tmpfile);
            //XmlTextWriter z = new XmlTextWriter(Console.Out);
            using (XmlTextWriter w = new XmlTextWriter(t))
            {
                w.Formatting = Formatting.Indented;

                w.WriteStartDocument();

                w.WriteStartElement("persoonlijst");
                w.WriteStartElement("persoon");
                w.WriteStartElement("naam");
                w.WriteRaw("Seppe");
                w.WriteEndElement();
                w.WriteEndElement();
                w.WriteEndElement();

                t.Close();

                XmlDocument doc = new XmlDocument();
                doc.PreserveWhitespace = true;
                try { doc.Load(tmpfile); }
                catch (System.IO.FileNotFoundException)
                {
                    Console.WriteLine("File wasnt found!");
                    Environment.Exit(0);
                }

                XmlNode root = doc.ChildNodes[2];
                Console.WriteLine(root.Name);
                //Display the contents of the child nodes.
                if (root.HasChildNodes)
                {
                    foreach (XmlNode node in root.ChildNodes)
                        if (node.HasChildNodes)
                        {
                            XmlNode child = node.ChildNodes[0];
                            Console.WriteLine(child.ToString());
                            for(int i = 0; i < child.ChildNodes.Count; i++)
                            {
                                Console.WriteLine(child.ChildNodes[i].InnerText);
                            }
                        }
                        else
                        {
                            Console.WriteLine(node.ToString());
                            for (int i = 0; i < root.ChildNodes.Count; i++)
                            {
                                Console.WriteLine(root.ChildNodes[i].InnerText);
                            }
                        }

                }
                /*
                t.Close();

                FileStream tr = File.OpenRead(tmpfile);
                XmlTextReader r = new XmlTextReader(tr);
                while (r.Read())
                {
                    Console.WriteLine(r.ReadString());
                }*/
            }

            
            //Console.Write(w.ToString());

        }
}
}