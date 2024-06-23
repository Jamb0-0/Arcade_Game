using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Курсовая_работа
{
    [DataContract]
    public class Save
    {
        [DataMember]
        public  int Money { get; set; } = 6000;
        [DataMember]
        public  byte Character { get; set; } = 0;
        [DataMember]
        public  byte Fence { get; set; } = 0;
        [DataMember]
        public List<RecordsData> records = new List<RecordsData>();
        [DataMember]
        public bool[] CharacterShop = new bool[3] { true, false, false };
        [DataMember]
        public bool[] FenceShop = new bool[2] { true, false };
        [DataMember]
        public byte SelectedCharacter { get; set; } = 0;
        [DataMember]
        public byte SelectedFence { get; set; } = 0;
    }
}
