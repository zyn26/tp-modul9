using System;
using System.IO;
using System.Text.Json;

namespace TP_MODUL9_103022400018.RuntimeConfiguration
{
    public class CovidConfig
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_deman { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        public CovidConfig()
        {
            LoadConfig();
        }

        public void LoadConfig()
        {
            string path = "RuntimeConfiguration/covid_config.json";

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var data = JsonSerializer.Deserialize<CovidConfig>(json);

                satuan_suhu = data.satuan_suhu;
                batas_hari_deman = data.batas_hari_deman;
                pesan_ditolak = data.pesan_ditolak;
                pesan_diterima = data.pesan_diterima;
            }
            else
            {
                SetDefault();
            }
        }

        public void SetDefault()
        {
            satuan_suhu = "celcius";
            batas_hari_deman = 14;
            pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }

        public void UbahSatuan()
        {
            if (satuan_suhu == "celcius")
                satuan_suhu = "fahrenheit";
            else
                satuan_suhu = "celcius";
        }
    }
}