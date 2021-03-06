using Movsisyan_Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Movsisyan_AttackSolverTest
{

    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test1()
        {

            var insts = FindImplementations();
            if (insts.Count == 0)
                throw new Exception(
                    "No implementation of IAttackCounter was found, make sure you add a reference to your project to AttackSolverTest");

            foreach (var inst in insts)
            {
                output.WriteLine("Testing " + inst.GetType().FullName);
                // Rook - ladja
                var res = inst.CountUnderAttack(ChessmanType.Rook, new Size(3, 2), new Point(1, 1),
                    new[] { new Point(2, 2), new Point(3, 1) });
                Assert.Equal(2, res);


                // Bishop - slon
               var res2 = inst.CountUnderAttack(ChessmanType.Bishop, new Size(4, 5), new Point(2, 2),
                    new[] { new Point(1, 1), new Point(1, 3), });
                Assert.Equal(3, res2);


                // Bishop - slon
                var res3 = inst.CountUnderAttack(ChessmanType.Bishop, new Size(4, 5), new Point(2, 2),
                    new[] { new Point(3, 3), new Point(1, 3), });
                Assert.Equal(2, res3);


                //Knight - kon
                var res4 = inst.CountUnderAttack(ChessmanType.Knight, new Size(3, 2), new Point(1, 1),
                    new[] { new Point(2, 2), new Point(3, 1) });
                Assert.Equal(1, res4);


            }

        }

        IList<IAttackCounter> FindImplementations()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(mytype => mytype.GetInterfaces().Contains(typeof(IAttackCounter)))
                .Select(type => (IAttackCounter)Activator.CreateInstance(type)).ToList();
        }
    }
}
