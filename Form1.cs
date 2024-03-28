using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using System.Speech.Synthesis;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace onsei_gosei
{
    public partial class Form1 : Form
    {

        private SpeechSynthesizer synthesizer;

        public Form1()
        {
            InitializeComponent();

            List<KeyValuePair<string, string>> cmbList = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("稚内", "011000")
                , new KeyValuePair<string, string>("旭川", "012010")
                , new KeyValuePair<string, string>("留萌", "012020")
                , new KeyValuePair<string, string>("網走", "013010")
                , new KeyValuePair<string, string>("北見", "013020")
                , new KeyValuePair<string, string>("紋別", "013030")
                , new KeyValuePair<string, string>("根室", "014010")
                , new KeyValuePair<string, string>("釧路", "014020")
                , new KeyValuePair<string, string>("帯広", "014030")
                , new KeyValuePair<string, string>("室蘭", "015010")
                , new KeyValuePair<string, string>("浦河", "015020")
                , new KeyValuePair<string, string>("札幌", "016010")
                , new KeyValuePair<string, string>("岩見沢", "016020")
                , new KeyValuePair<string, string>("倶知安", "016030")
                , new KeyValuePair<string, string>("函館", "017010")
                , new KeyValuePair<string, string>("江差", "017020")
                , new KeyValuePair<string, string>("青森", "020010")
                , new KeyValuePair<string, string>("むつ", "020020")
                , new KeyValuePair<string, string>("八戸", "020030")
                , new KeyValuePair<string, string>("盛岡", "030010")
                , new KeyValuePair<string, string>("宮古", "030020")
                , new KeyValuePair<string, string>("大船渡", "030030")
                , new KeyValuePair<string, string>("仙台", "040010")
                , new KeyValuePair<string, string>("白石", "040020")
                , new KeyValuePair<string, string>("秋田", "050010")
                , new KeyValuePair<string, string>("横手", "050020")
                , new KeyValuePair<string, string>("山形", "060010")
                , new KeyValuePair<string, string>("米沢", "060020")
                , new KeyValuePair<string, string>("酒田", "060030")
                , new KeyValuePair<string, string>("新庄", "060040")
                , new KeyValuePair<string, string>("福島", "070010")
                , new KeyValuePair<string, string>("小名浜", "070020")
                , new KeyValuePair<string, string>("若松", "070030")
                , new KeyValuePair<string, string>("水戸", "080010")
                , new KeyValuePair<string, string>("土浦", "080020")
                , new KeyValuePair<string, string>("宇都宮", "090010")
                , new KeyValuePair<string, string>("大田原", "090020")
                , new KeyValuePair<string, string>("前橋", "100010")
                , new KeyValuePair<string, string>("みなかみ", "100020")
                , new KeyValuePair<string, string>("さいたま", "110010")
                , new KeyValuePair<string, string>("熊谷", "110020")
                , new KeyValuePair<string, string>("秩父", "110030")
                , new KeyValuePair<string, string>("千葉", "120010")
                , new KeyValuePair<string, string>("銚子", "120020")
                , new KeyValuePair<string, string>("館山", "120030")
                , new KeyValuePair<string, string>("東京", "130010")
                , new KeyValuePair<string, string>("大島", "130020")
                , new KeyValuePair<string, string>("八丈島", "130030")
                , new KeyValuePair<string, string>("父島", "130040")
                , new KeyValuePair<string, string>("横浜", "140010")
                , new KeyValuePair<string, string>("小田原", "140020")
                , new KeyValuePair<string, string>("新潟", "150010")
                , new KeyValuePair<string, string>("長岡", "150020")
                , new KeyValuePair<string, string>("高田", "150030")
                , new KeyValuePair<string, string>("相川", "150040")
                , new KeyValuePair<string, string>("富山", "160010")
                , new KeyValuePair<string, string>("伏木", "160020")
                , new KeyValuePair<string, string>("金沢", "170010")
                , new KeyValuePair<string, string>("輪島", "170020")
                , new KeyValuePair<string, string>("福井", "180010")
                , new KeyValuePair<string, string>("敦賀", "180020")
                , new KeyValuePair<string, string>("甲府", "190010")
                , new KeyValuePair<string, string>("河口湖", "190020")
                , new KeyValuePair<string, string>("長野", "200010")
                , new KeyValuePair<string, string>("松本", "200020")
                , new KeyValuePair<string, string>("飯田", "200030")
                , new KeyValuePair<string, string>("岐阜", "210010")
                , new KeyValuePair<string, string>("高山", "210020")
                , new KeyValuePair<string, string>("静岡", "220010")
                , new KeyValuePair<string, string>("網代", "220020")
                , new KeyValuePair<string, string>("三島", "220030")
                , new KeyValuePair<string, string>("浜松", "220040")
                , new KeyValuePair<string, string>("名古屋", "230010")
                , new KeyValuePair<string, string>("豊橋", "230020")
                , new KeyValuePair<string, string>("津", "240010")
                , new KeyValuePair<string, string>("尾鷲", "240020")
                , new KeyValuePair<string, string>("大津", "250010")
                , new KeyValuePair<string, string>("彦根", "250020")
                , new KeyValuePair<string, string>("京都", "260010")
                , new KeyValuePair<string, string>("舞鶴", "260020")
                , new KeyValuePair<string, string>("大阪", "270000")
                , new KeyValuePair<string, string>("神戸", "280010")
                , new KeyValuePair<string, string>("豊岡", "280020")
                , new KeyValuePair<string, string>("奈良", "290010")
                , new KeyValuePair<string, string>("風屋", "290020")
                , new KeyValuePair<string, string>("和歌山", "300010")
                , new KeyValuePair<string, string>("潮岬", "300020")
                , new KeyValuePair<string, string>("鳥取", "310010")
                , new KeyValuePair<string, string>("米子", "310020")
                , new KeyValuePair<string, string>("松江", "320010")
                , new KeyValuePair<string, string>("浜田", "320020")
                , new KeyValuePair<string, string>("西郷", "320030")
                , new KeyValuePair<string, string>("岡山", "330010")
                , new KeyValuePair<string, string>("津山", "330020")
                , new KeyValuePair<string, string>("広島", "340010")
                , new KeyValuePair<string, string>("庄原", "340020")
                , new KeyValuePair<string, string>("下関", "350010")
                , new KeyValuePair<string, string>("山口", "350020")
                , new KeyValuePair<string, string>("柳井", "350030")
                , new KeyValuePair<string, string>("萩", "350040")
                , new KeyValuePair<string, string>("徳島", "360010")
                , new KeyValuePair<string, string>("日和佐", "360020")
                , new KeyValuePair<string, string>("高松", "370000")
                , new KeyValuePair<string, string>("松山", "380010")
                , new KeyValuePair<string, string>("新居浜", "380020")
                , new KeyValuePair<string, string>("宇和島", "380030")
                , new KeyValuePair<string, string>("高知", "390010")
                , new KeyValuePair<string, string>("室戸岬", "390020")
                , new KeyValuePair<string, string>("清水", "390030")
                , new KeyValuePair<string, string>("福岡", "400010")
                , new KeyValuePair<string, string>("八幡", "400020")
                , new KeyValuePair<string, string>("飯塚", "400030")
                , new KeyValuePair<string, string>("久留米", "400040")
                , new KeyValuePair<string, string>("佐賀", "410010")
                , new KeyValuePair<string, string>("伊万里", "410020")
                , new KeyValuePair<string, string>("長崎", "420010")
                , new KeyValuePair<string, string>("佐世保", "420020")
                , new KeyValuePair<string, string>("厳原", "420030")
                , new KeyValuePair<string, string>("福江", "420040")
                , new KeyValuePair<string, string>("熊本", "430010")
                , new KeyValuePair<string, string>("阿蘇乙姫", "430020")
                , new KeyValuePair<string, string>("牛深", "430030")
                , new KeyValuePair<string, string>("人吉", "430040")
                , new KeyValuePair<string, string>("大分", "440010")
                , new KeyValuePair<string, string>("中津", "440020")
                , new KeyValuePair<string, string>("日田", "440030")
                , new KeyValuePair<string, string>("佐伯", "440040")
                , new KeyValuePair<string, string>("宮崎", "450010")
                , new KeyValuePair<string, string>("延岡", "450020")
                , new KeyValuePair<string, string>("都城", "450030")
                , new KeyValuePair<string, string>("高千穂", "450040")
                , new KeyValuePair<string, string>("鹿児島", "460010")
                , new KeyValuePair<string, string>("鹿屋", "460020")
                , new KeyValuePair<string, string>("種子島", "460030")
                , new KeyValuePair<string, string>("名瀬", "460040")
                , new KeyValuePair<string, string>("那覇", "471010")
                , new KeyValuePair<string, string>("名護", "471020")
                , new KeyValuePair<string, string>("久米島", "471030")
                , new KeyValuePair<string, string>("南大東", "472000")
                , new KeyValuePair<string, string>("宮古島", "473000")
                , new KeyValuePair<string, string>("石垣島", "474010")
                , new KeyValuePair<string, string>("与那国島", "474020")
            };

            cmbPlace.DataSource = cmbList;
            cmbPlace.DisplayMember = "key";
            cmbPlace.ValueMember = "value";
            cmbPlace.SelectedValue = "200010";
        }

        private string Tenki()
        {
            string baseUrl = "https://weather.tsukumijima.net/api/forecast";

            string url = $"{baseUrl}?city={cmbPlace.SelectedValue}";
            string json = new HttpClient().GetStringAsync(url).Result;
            JObject jobj = JObject.Parse(json);

            //return (string)(jobj["forecasts"][0]["detail"]["weather"] as JValue).Value;//今日の天気の取得
            return (string)(jobj["description"]["text"] as JValue).Value;//今日の天気の取得
        }

        private async void BtnPlay_Click(object sender, EventArgs e)
        {
            btnPlay.Enabled = false;
            synthesizer = new SpeechSynthesizer();
            synthesizer.SetOutputToDefaultAudioDevice();
            var builder = new PromptBuilder();
            builder.StartVoice(new CultureInfo("jp-JP"));
            builder.AppendText(Tenki());
            builder.EndVoice();

            await Task.Run(() => {
                synthesizer.Speak(builder);
            });
            btnPlay.Enabled = true;
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            synthesizer.Pause();
            synthesizer.Dispose();
            btnPlay.Enabled = true;
        }

        private void TmrNormal_Tick(object sender, EventArgs e)
        {
            string now = DateTime.Now.ToString("HH:mm");
            if (now.Equals("00:05") || now.Equals("06:05") || now.Equals("12:05") || now.Equals("18:05"))
            {
                btnPlay.PerformClick();
            }
        }
    }
}
