using System;

namespace Hoge
{
	static class MaybeMonad
	{
		public static IMaybe<TResult> Bind<T, TResult>(this IMaybe<T> m, Func<T, IMaybe<TResult>> func)
			=> m switch
			{
				Nothing<T> => new Nothing<TResult>(),
				Just<T> x => func(x.Value),
			};

		public static IMaybe<T> Join<T>(this IMaybe<IMaybe<T>> m) => m.Bind(x => x);
	}
}