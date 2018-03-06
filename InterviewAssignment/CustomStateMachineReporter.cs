using Appccelerate.StateMachine.Machine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewAssignment
{

    /// <summary>
    /// Provides way to customize state reporting.
    /// 
    /// By default you cannot get container of states from Appccelerate state machine.
    /// This class can be used for that. Also it has StateToString method to enable
    /// printing hierarchical states.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <typeparam name="TEvent"></typeparam>
    public class CustomStateMachineReporter<TState, TEvent> : IStateMachineReport<TState, TEvent>
            where TState : IComparable
    where TEvent : IComparable

    {
        IEnumerable<IState<TState, TEvent>> myStates;
        

        public IEnumerable<IState<TState, TEvent>> States
        {
            get
            {
                return myStates;
            }
        }

        public void Report(string name, IEnumerable<IState<TState, TEvent>> states, Initializable<TState> initialStateId)
        {
            myStates = states;
        }

        public string StateToString(TState state, string separator = ".")
        {
           
            //Your assignment is here!
            //Tip: You find state machine hierarchy on States property (or myStates field). 
            //You should go through the states and print that on what hierarchy path the current state
            //is found. So if state is Initializing this method should return "Down.Initializing" because
            //"Initializing" is substate of "Down".
            // String currentSt = state.ToString();
            // foreach (currenSt  in Enum.GetValues(state.GetType(){ }

            //Console.WriteLine(state.ToString());
            // String currentSt = state.ToString();

            var iterator = myStates.GetEnumerator();
            // move to next state
            while (iterator.MoveNext())
            {
                if (iterator.Current.ToString() == state.ToString())
                {
                    return GetState(iterator.Current, separator);
                }

            }
            return null;
        }
        //recursive func
        String GetState(IState<TState, TEvent> state, string separator)
        {
            if (state.SuperState != null)
                return GetState(state.SuperState, separator) + separator + state.ToString();
            else
                return state.ToString();
            

        }
    }
}
        
   

