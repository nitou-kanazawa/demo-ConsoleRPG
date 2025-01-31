using System;

// [REF]
//  qiita: DDD に入門するなら、まずは ValueObject だけでもいいんじゃない？ https://qiita.com/t2-kob/items/9d9dd038fe7497756dbf
//  _: C#でドメイン駆動開発ValueObjectでプログラムの複雑さを取り除く https://anderson02.com/cs/ddd/ddd10/
//  _: 値オブジェクトを実装する https://learn.microsoft.com/ja-jp/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects

namespace RPG.Domain.Shared {

    // [NOTE]
    //  実装コード量等の面から考えるとおそらくrecord class型の方がメリットが多いが，
    //  record型の扱いや値オブジェクト自体に慣れていないため，今回は挙動が把握しやすい継承で実装する．

    /// <summary>
    /// ValueObjectの基底クラス．
    /// </summary>
    public abstract class ValueObject<T> where T : ValueObject<T> {

        public override bool Equals(object obj) {
            return obj is T other && EqualsCore(other); 
        }

        public abstract override int GetHashCode();

        protected abstract bool EqualsCore(T other);


        /// ----------------------------------------------------------------------------
        #region Static

        public static bool operator ==(ValueObject<T> vo1, ValueObject<T> vo2) {
            if (vo1 is null && vo2 is null) return true;
            if (vo1 is null || vo2 is null) return false;

            return Equals(vo1, vo2);
        }

        public static bool operator !=(ValueObject<T> vo1, ValueObject<T> vo2) {
            return !(vo1 == vo2);
        }
        #endregion
    }
}