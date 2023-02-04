namespace Pokemon.Combat
{
	public enum MoveStatus
	{
		Success,
		Fail
	}

	public struct MoveReponse
	{
		public MoveStatus MoveStatus {get;}
	}

	public struct DamageResponse
	{
		public Pokemon Target {get;}
		public bool TargetDefeated {get;}
	}
}