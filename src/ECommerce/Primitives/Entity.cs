using ReactiveUI;

namespace ECommerce.Primitives
{
    public abstract class Entity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; protected set; }

        protected Entity()
        {

        }

        public override string ToString()
        {
            return $"Id: {Id}";
        }
    }
}
