namespace StatusCheck
{
    public class Event
    {
        public string Id;
        public string ExternalId;
        public string ExternalParentId;
        public string EventId;
        public string BetlabEventKey;
        public Name[] Name;
        public GroupComment[] GroupComment;
        public string Position;
        public string SportType;
        public string Country;
        public string Gender;
        public string AgeCategory;
        public string Trader;
        public int EventKind;
        public string ScroreBoard;
        public string GroupName;
        public string GroupId;
        public string GroupTag;
        public string ChampionshipTag;
        public int LineStatus;
        public int ExpressSize;
        public int EventKindPm;
        public string Url;
        public string MarketTemplate;
        public string EventType;
        public OddData OddData;
    }

    public class Name
    {
        public string Lang;
        public string Text;
    }

    public class GroupComment
    {
        public string Lang;
        public string Text;
    }

    public class OddData
    {
        public string ContentType;
        public string Data;
    }
}