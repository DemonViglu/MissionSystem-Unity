namespace DemonViglu.MissionSystem {
    public interface IMission {
        public abstract void OnMissionBegin(int missionID);
        public abstract void OnMissionEnd(int missionID);
        public abstract void OnMissionCompleted(int missionID);
        public abstract void OnMissionOver(int missionID);

    }

}