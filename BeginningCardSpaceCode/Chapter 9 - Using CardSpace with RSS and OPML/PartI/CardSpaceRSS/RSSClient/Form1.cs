using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Rss;

namespace RSSClient
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnRetrieveFeed_Click(object sender, EventArgs e)
        {
            RSSServiceClient client = new RSSServiceClient();
            Rss.RssFeed feed = client.GetFeed();
            DisplayChannel(feed.Channels[0]);
        }

        private void btnGetOPML_Click(object sender, EventArgs e)
        {
            OPMLServiceClient client = new OPMLServiceClient();
            Rss.OPML opml = client.GetOPML();
            DisplayOutlinesInControl(opml);
        }


        private void DisplayOutlinesInControl(OPML opml)
        {
            dgvOPML.Rows.Clear();
            int gridRowNbr = 0;
            int ParentIndex = 0;
            Color evenRowColorValue = Color.AliceBlue;
            Color oddRowColorValue = Color.LightSteelBlue;
            foreach (OPMLOutline outline in opml.Body.Outlines)
            {

                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCheckBoxCell check = new DataGridViewCheckBoxCell();
                DataGridViewTextBoxCell count = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell text = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell categories = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell description = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell xmlUrl = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell type = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell version = new DataGridViewTextBoxCell();


                row.DefaultCellStyle.Font = this.Font;
                if (gridRowNbr % 2 == 0)
                {
                    row.DefaultCellStyle.BackColor = oddRowColorValue;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = evenRowColorValue;
                }

                //Set the tag value for the row to the outline element
                row.Tag = outline;

                text.Value = outline.Text;

                //Set the tool tile to the description
                text.ToolTipText = outline.Description;
                categories.Value = outline.Categories;
                description.Value = outline.Description;
                xmlUrl.Value = outline.XmlUrl;
                type.Value = outline.Type;
                version.Value = outline.Version;

                row.Cells.Add(check);
                row.Cells.Add(text);
                row.Cells.Add(categories);
                row.Cells.Add(description);
                row.Cells.Add(xmlUrl);
                row.Cells.Add(type);
                row.Cells.Add(version);

                dgvOPML.Rows.Add(row);

                gridRowNbr++;
            }



        }

        private void dgvOPML_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0: //Check
                    break;
                case 1: //Text
                    //The following line would return the URL for the feed
                    //dgvOPML.Rows[e.RowIndex].Cells[4].Value.ToString();

                    //In Part I of this chapter, we use a fixed feed
                    RSSServiceClient client = new RSSServiceClient();
                    Rss.RssFeed feed = client.GetFeed();
                    DisplayChannel(feed.Channels[0]);
                    //Display the feed in the secondary data grid

                    break;
                case 2: //Categories
                    break;
                case 3: //Description
                    break;
                case 4: //xmlUrl
                    break;
                case 5: // type
                    break;
                case 6: //version
                    break;
                default:
                    break;
            }
        }


        protected void DisplayChannel(Rss.RssChannel channel)
        {
            datagridItems.Rows.Clear();

            lblChannelSummary.Text = channel.Summary;
            lblChannelTitle.Text = channel.Title;

            int ParentIndex;
            ParentIndex = 0;
            int ParentRow = ParentIndex + 1;



            string ChannelTitle;
            ChannelTitle = channel.Title;
           

            int gridRowNbr = ParentIndex + 1;
            ParentIndex = -1;
            foreach (RssItem item in channel.Items)
            {

                ///---------------------------------------
                ///
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell date = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell title = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell description = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell duration = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell rating = new DataGridViewTextBoxCell();

                datagridItems.Columns[0].Width = 75;
                datagridItems.Columns[1].Width = (int)((double)(datagridItems.Width - 225) * (double).6);
                datagridItems.Columns[2].Width = (int)((double)(datagridItems.Width - 225) * (double).39);
                datagridItems.Columns[3].Width = 75;
                datagridItems.Columns[4].Width = 75;



                if (gridRowNbr % 2 == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.AliceBlue;
                }



                date.Value = item.PubDate;
                date.Tag = item;
                title.Value = item.Title;

                if (item.Duration == null || item.Duration == "")
                { duration.Value = "None"; }
                else
                { duration.Value = item.Duration; }

                if (item.Subtitle == null || item.Subtitle == "")
                { description.Value = "None"; }
                else
                { description.Value = item.Subtitle; }


                if (item.Rating == null || item.Rating == "")
                { rating.Value = "None"; }
                else
                { rating.Value = item.Rating; }

                row.Cells.Add(date);
                row.Cells.Add(title);
                row.Cells.Add(description);
                row.Cells.Add(duration);
                row.Cells.Add(rating);

                datagridItems.Rows.Add(row);

                gridRowNbr++;
            }
            if (datagridItems.Rows.Count > 0)
            {
                datagridItems.Rows[0].Selected = false;
                datagridItems.Rows[0].Selected = true;
            }
        }

        private void DisplayItem(RssItem item)
        {
            webBrowser1.DocumentText = item.Description;
            lblItemTitle.Text = item.Title;
        
        }

        private void datagridItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                object o = datagridItems.Rows[e.RowIndex].Cells[0].Tag;
                if (o != null)
                {
                    Type objectType = o.GetType();

                    switch (objectType.Name)
                    {
                        case "RssEnclosure":

                            break;
                        case "RssItem":
                            RssItem item = (RssItem)o;
                            DisplayItem(item);


                            break;
                        case "RssChannel":

                            break;
                        default:
                            break;
                    }
                }
            }



        }
    }
}