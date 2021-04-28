using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using Pada1.BBCore;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is a basic action to associate a Boolean to a variable.
    /// </summary>
    [Action("Basic/GetRandomValue")]
    [Help("Sets a value to a boolean variable")]
    public class GetRandomValue : BasePrimitiveAction
    {
       
        ///<value>OutPut Boolean Parameter.</value>
        [OutParam("var")]
        [Help("output variable")]
        public double var;
                      

        /// <summary>Initialization Method of SetBool.</summary>
        /// <remarks>Initializes the Boolean value.</remarks>
        public override void OnStart()
        {
            System.Random rnd = new System.Random();
            var = rnd.NextDouble();
        }
        /// <summary>Method of Update of SetBool.</summary>
        /// <remarks>Complete the task.</remarks>
        public override TaskStatus OnUpdate()
        {
            return TaskStatus.COMPLETED;
        }
    }
}
