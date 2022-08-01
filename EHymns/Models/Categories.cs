namespace EHymns.Models
{

    public class Categories
    {
        [JsonProperty("admonition")]
        public List<int> Admonition { get; set; }

        [JsonProperty("adoration")]
        public List<int> Adoration { get; set; }

        [JsonProperty("assurance & confidence")]
        public List<int> AssuranceConfidence { get; set; }

        [JsonProperty("invitation")]
        public List<int> Invitation { get; set; }

        [JsonProperty("prayer")]
        public List<int> Prayer { get; set; }

        [JsonProperty("rapture")]
        public List<int> Rapture { get; set; }

        [JsonProperty("commitment & consecration")]
        public List<int> CommitmentConsecration { get; set; }

        [JsonProperty("warning & judgment")]
        public List<int> WarningJudgment { get; set; }

        [JsonProperty("The lord's love and care")]
        public List<int> TheLordSLoveAndCare { get; set; }

        [JsonProperty("sanctification")]
        public List<int> Sanctification { get; set; }

        [JsonProperty("special occasions")]
        public List<int> SpecialOccasions { get; set; }

        [JsonProperty("blood of jesus")]
        public List<int> BloodOfJesus { get; set; }

        [JsonProperty("christian service & reward")]
        public List<int> ChristianServiceReward { get; set; }

        [JsonProperty("christian life")]
        public List<int> ChristianLife { get; set; }

        [JsonProperty("christ our saviour")]
        public List<int> ChristOurSaviour { get; set; }

        [JsonProperty("evangelism")]
        public List<int> Evangelism { get; set; }

        [JsonProperty("grace & forgiveness")]
        public List<int> GraceForgiveness { get; set; }

        [JsonProperty("divine healing")]
        public List<int> DivineHealing { get; set; }

        [JsonProperty("conflict & victory")]
        public List<int> ConflictVictory { get; set; }

        [JsonProperty("heaven")]
        public List<int> Heaven { get; set; }

        [JsonProperty("holy spirit")]
        public List<int> HolySpirit { get; set; }
    }

}