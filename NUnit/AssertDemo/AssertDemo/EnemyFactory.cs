namespace AssertDemo {
	public class EnemyFactory {
		public object Create(bool isBoss) {
			if (isBoss)
			{
				return new BossEnemy();
			}

			return new NormalEnemy();
		}
	}
}
