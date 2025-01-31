using System;

namespace RPG.Domain.Shared {

    /// <summary>
    /// ���ʎq��\��ValueObject�D
    /// </summary>
    public abstract class IdentifierBase<T> : IEquatable<T>
        where T : IdentifierBase<T>, new() {

        public Guid Value { get; }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        public IdentifierBase(Guid value) {
            if (value == Guid.Empty)
                throw new ArgumentException("Identifier value cannot be Guid.Empty.", nameof(value));

            Value = value;
        }

        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        public IdentifierBase() : this(Guid.NewGuid()) { }

        /// <summary>
        /// 
        /// </summary>
        public override bool Equals(object obj) {
            return obj is IdentifierBase<T> other && Equals(other);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Equals(T other) {
            return other != null && Value.Equals(other.Value);
        }

        /// <summary>
        /// �n�b�V���l�̎擾�D
        /// </summary>
        public override int GetHashCode() {
            return Value.GetHashCode();
        }

        /// <summary>
        /// ������ւ̕ϊ��D
        /// </summary>
        public override string ToString() {
            return $"{GetType().Name}({Value.ToString()})";
        }


        /// ----------------------------------------------------------------------------
        #region Static
        public static bool operator ==(IdentifierBase<T> left, IdentifierBase<T> right) => Equals(left, right);
        public static bool operator !=(IdentifierBase<T> left, IdentifierBase<T> right) => !Equals(left, right);
        #endregion
    }
}
