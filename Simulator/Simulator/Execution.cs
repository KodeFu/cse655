using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
	public class Execution
	{
		public const int ERROR_CREDIT_OVERFLOW = 1;
		public void Process(Instruction i, ref Machine m)
		{
			// No instruction, return
			if (i.instruction == String.Empty)
			{
				m.ip++;
				return;
			}

			// Process instruction
			switch (i.instruction)
			{
				case "rst":
					rst(ref i, ref m);
					break;
				case "rbt":
					rbt(ref i, ref m);
					break;
				case "halt":
					halt(ref i, ref m);
					break;
				case "off":
					off(ref i, ref m);
					break;
				case "bccl":
					bccl(ref i, ref m);
					break;
				case "bctg":
					bctg(ref i, ref m);
					break;
				case "log":
					log(ref i, ref m);
					break;
				case "ding":
					ding(ref i, ref m);
					break;
				case "vols":
					vols(ref i, ref m);
					break;
				case "crda":
					crda(ref i, ref m);
					break;
				case "crdc":
					crdc(ref i, ref m);
					break;
				case "crdb":
					crdb(ref i, ref m);
					break;
				case "bkpy":
					bkpy(ref i, ref m);
					break;
				case "bkbl":
					bkbl(ref i, ref m);
					break;
				case "bkad":
					bkad(ref i, ref m);
					break;
				case "bkcl":
					bkcl(ref i, ref m);
					break;
				case "jpot":
					jpot(ref i, ref m);
					break;
				case "pull":
					pull(ref i, ref m);
					break;
				case "btpl":
					btnp(ref i, ref m);
					break;
				case "spin":
					spin(ref i, ref m);
					break;
				case "strt":
					strt(ref i, ref m);
					break;
				case "wait":
					wait(ref i, ref m);
					break;
				case "end":
					end(ref i, ref m);
					break;
				case "abrt":
					abrt(ref i, ref m);
					break;
				case "whlv":
					whlv(ref i, ref m);
					break;
				case "payf":
					payf(ref i, ref m);
					break;
				case "drwr":
					drwr(ref i, ref m);
					break;
				case "disp":
					disp(ref i, ref m);
					break;
				case "regr":
					regr(ref i, ref m);
					break;
				case "regi":
					regi(ref i, ref m);
					break;
				case "regh":
					regh(ref i, ref m);
					break;
				case "regl":
					regl(ref i, ref m);
					break;
				case "memr":
					memr(ref i, ref m);
					break;
				case "memm":
					memm(ref i, ref m);
					break;
				case "addr":
					addr(ref i, ref m);
					break;
				case "subr":
					subr(ref i, ref m);
					break;
				case "mulr":
					mulr(ref i, ref m);
					break;
				case "divr":
					divr(ref i, ref m);
					break;
				case "modr":
					modr(ref i, ref m);
					break;
				case "shl":
					shl(ref i, ref m);
					break;
				case "shr":
					shr(ref i, ref m);
					break;
				case "and":
					and(ref i, ref m);
					break;
				case "or":
					or(ref i, ref m);
					break;
				case "jmp":
					jmp(ref i, ref m);
					break;
				case "br":
					br(ref i, ref m);
					break;
				case "bls":
					bls(ref i, ref m);
					break;
				case "ble":
					ble(ref i, ref m);
					break;
				case "bge":
					bge(ref i, ref m);
					break;
				case "cmp":
					cmp(ref i, ref m);
					break;
				case "rand":
					rand(ref i, ref m);
					break;
				default:
					m.ip++;
					break;
			}
		}

		// RESET
		// Resets the machine.
		// 16-bit type
		// opcode, null, null, null
		// rst
		void rst(ref Instruction i, ref Machine m)
		{
			m.Initialize();
		}

		// REBOOT
		// Reboot the machine.
		// 16-bit type
		// opcode, null, null, null
		// rbt
		void rbt(ref Instruction i, ref Machine m)
		{
			m.Initialize();
		}

		// HALT
		// Halts the machine. Only reset or reboot can get out of a halt.
		// 16-bit type
		// opcode, null, null, null
		// halt
		void halt(ref Instruction i, ref Machine m)
		{
			m.runstate = 1;
		}

		// OFF
		// Turn machine off.
		// 16-bit type
		// opcode, null, null, null
		// off
		void off(ref Instruction i, ref Machine m)
		{
			m.runstate = 1;
		}

		// BEACON COLOR
		// Set the beacon color.
		// 16-bit type
		// opcode, null, null, mode { 0=green, 1=yellow, 2=orange, 3=red}
		// bccl 1 # yellow
		void bccl(ref Instruction i, ref Machine m)
		{
			m.beaconColor = int.Parse(i.field[0]);

			m.ip++;
		}

		// BEACON TOGGLE
		// Turn beacon on or off. The beacon is on top of machine as a visual indicator
		// to indicate various machine states.
		// 16-bit type
		// opcode, null, null, mode { 0=off, 1=on }
		// bctg 1 # beacon on
		// bctg 0 # beacon off
		void bctg(ref Instruction i, ref Machine m)
		{
			m.beacon = int.Parse(i.field[0]);

			m.ip++;
		}

		// LOG
		// Log an error code to the error device. Code gets written to the error
		// register which gets consumed by the log unit.
		// 32-bit type
		// opcode, null, log code
		// log 782 # log error code 782 to device
		void log(ref Instruction i, ref Machine m)
		{
			m.error = int.Parse(i.field[0]);

			m.ip++;
		}

		// DING
		// Sound the external bell. This can be used to indicate winnings.
		// 16-bit type
		// opcode, null, null, mode { 0=off, 1=on/continuous, 2=5 dings, 3=10 dings }
		// ding 1 # continuous dinging
		void ding(ref Instruction i, ref Machine m)
		{
			m.ding = int.Parse(i.field[0]);

			m.ip++;
		}

		// VOLUME SET
		// vols(ref i, ref m);
		// 16-bit type
		// opcode, null, null, mode { 0=off, 1=soft, 2=midrange, 3=loud}
		// vols 2 # set to midrange volume
		void vols(ref Instruction i, ref Machine m)
		{
			m.volume = int.Parse(i.field[0]);

			m.ip++;
		}

		// CREDIT ADD
		// Credits are the generic unit for game play. Credits can be added by hitting 
		// the button (or pull lever) for 1, 2, or 3 play. Max three credits per play.
		// 16-bit type
		// opcode, null, null, mode { 0=NA, 1=one credit, 2=two credit, 3=three credits }
		// crda 2 # add two credits for play
		void crda(ref Instruction i, ref Machine m)
		{
			m.credits = int.Parse(i.field[0]);

			m.ip++;
		}

		// CREDIT CLEAR
		// Clears credits. Usually happens after a play.
		// 16-bit type
		// opcode, null, null, null
		// crdc # clear credits stored
		void crdc(ref Instruction i, ref Machine m)
		{
			m.credits = 0;

			m.ip++;
		}

		// CREDIT BALANCE
		// Gets the credits balance.
		// 16-bit type
		// opcode, rX, null, null
		// crdb r0 # put credit balance into r0
		void crdb(ref Instruction i, ref Machine m)
		{
			m.regs["r0"] = m.credits;

			m.ip++;
		}

		// BANK PAY
		// Pay from the bank. If not enough credits, no payout error is set.
		// 32-bit type
		// opcode, null, credit amount
		// bkpy  25  # pay 25 credits from bank
		void bkpy(ref Instruction i, ref Machine m)
		{
			int payAmount = int.Parse(i.field[0]);
			if (m.credits >= payAmount)
			{
				m.bank -= payAmount;
			}
			else
			{
				m.error = ERROR_CREDIT_OVERFLOW;
			}
		}

		// BANK BALANCE
		// Get bank balance; rX contains bank register balance.
		// 16-bit type
		// opcode, rX, null, null
		// bkbl r0 # put bank balance into r0
		void bkbl(ref Instruction i, ref Machine m)
		{
			m.regs[i.field[0]] = m.bank;

			m.ip++;
		}

		// BANK ADD
		// Add credits to bank. Credits are added which is reflected in the	redits register.
		// But, the bank must be updated too. This instuction adds to the bank.
		// 16-bit type
		// opcode, null, null, mode { 0=NA, 1=one credit, 2=two credit, 3=three credits }
		// bkad 3 # add three credits to the bank
		void bkad(ref Instruction i, ref Machine m)
		{
			m.bank += int.Parse(i.field[0]);

			m.ip++;
		}

		// BANK CLEAR
		// All bank credits clear. Usually occurs during after a jackpot or when EOD tally when
		// all credits withdrawn.
		// 16-bit type
		// opcode, null, null, null
		// bkcl # clear the credits in the bank
		void bkcl(ref Instruction i, ref Machine m)
		{
			m.bank = 0;

			m.ip++;
		}

		// JACKPOT
		// Pay full bank on jackpot.
		// 16-bit type
		// opcode, null null, null
		// jpot # pay the full bank amount
		void jpot(ref Instruction i, ref Machine m)
		{
			m.bank = 0;

			m.ip++;
		}

		// PULL
		// Pull lever. Can specify credit. The credits can be determined by number of credits 
		// (1, 2, 3). Only three credits can be played at a time.
		// 16-bit type
		// opcode, null, null, mode { 0=NA, 1=one credit, 2=two credit, 3=three credits }
		// pull 3 # pull lever with three credits
		void pull(ref Instruction i, ref Machine m)
		{
			m.credits = int.Parse(i.field[0]);

			m.ip++;
		}

		// BUTTON PLAY
		// Play credit.
		// 16-bit type
		// opcode, null, null, mode { 0=NA, 1=one credit, 2=two credit, 3=three credits }
		// btnp 3 # push button and play three credits
		void btnp(ref Instruction i, ref Machine m)
		{
			m.credits = int.Parse(i.field[0]);

			m.ip++;
		}

		// SPIN
		// Spin all wheels.
		// 16-bit type
		// opcode, rX, null, null
		//   rX 0=lose; 1=win
		// spin r0 # spins the wheels; r0 contain results.
		void spin(ref Instruction i, ref Machine m)
		{
			Random random = new Random();
			m.regs[i.field[0]] = random.Next(0, 2);

			m.ip++;
		}

		// START GAMEPLAY
		// Start a game.This is a special state where inputs including credits, buttons, 
		// pulls are deactived.Also payout factors are reset.
		// 16-bit type
		// opcode, null, null, null
		// strt # start a gameplay session
		void strt(ref Instruction i, ref Machine m)
		{
			// Simulation:
			//   - Dactivate inputs
			//	 - These would be handled through sytem
			//     GPIOs (general purpose IO).
			m.runstate = 2; 

			m.ip++;
		}

		// WAIT FOR ACTIVITY TO COMPLETE
		// Also, wait for service which means door is open or system is being services.
		// opcode, null, null, mode { 0=NA, 1=spin, 2=payout, 3=service }
		// 16-bit type
		// wait 1 # wait for wheel spin to complete
		void wait(ref Instruction i, ref Machine m)
		{
			// Simulation:
			//   - This would wait for an IO activity to complete.
			//   - Activities:
			//       SPIN    - spin completion
			//       PAYOUT  - credit dispense complete
			//       SERVICE - cabinet service complete

			// Simulate IO activity; wait .1 seconds
			System.Threading.Thread.Sleep(100);

			m.ip++;
		}

		// END GAMEPLAY
		// End of a gameplay.Payfactor has been determined and up for grabs.Pay factor
		// uses a preprogrammed table for winnings.
		// 16-bit type
		// opcode, null, null, null
		// end # end of gameplay
		void end(ref Instruction i, ref Machine m)
		{
			// Simulation:
			//   - Reactivate inputs
			//	 - These would be handled through sytem
			//     GPIOs (general purpose IO).
			m.runstate = 0;

			m.ip++;
		}

		// ABORT GAMEPLAY
		// Aborts a gameplay
		// 16-bit type
		// opcode, null, null, null
		// abrt # abort gameplay session
		void abrt(ref Instruction i, ref Machine m)
		{
			// Call end to reactivate system
			// IP incremented in end, so we don't
			// do it here.
			end(ref i, ref m);
		}

		// WHEEL POS
		// Get wheel position given the wheel.
		// 16-bit type
		// opcode, rX, rY, null
		//   rX wheel number
		//   rY wheel position 0..9
		// whlv r0, r1 # r0 is wheel position; r1 returned pos
		void whlv(ref Instruction i, ref Machine m)
		{
			// Simulation
			//   - Return random wheel position
			Random random = new Random();
			m.regs[i.field[0]] = random.Next(0, 10);

			m.ip++;
		}

		// GET PAYOUT FACTOR
		// This is the factor used for calculating winning.
		// 16-bit type
		// opcode, rX, null, null
		// payf r0 # r0 contains the payout factor.
		void payf(ref Instruction i, ref Machine m)
		{
			m.regs[i.field[0]] = m.credits;

			m.ip++;
		}

		// OPEN DRAWR
		// Open the money drawer; i.e.dispenser.
		// 16-bit type
		// opcode, null, null, { 0=NA, 1=OPEN, 2=CLOSE, 3=NA }
		// drwr 1 # open drawer to dispense
		void drwr(ref Instruction i, ref Machine m)
		{
			// Simulation:
			//   - Open credit dispense drawer
			//	 - These would be handled through sytem
			//     GPIOs (general purpose IO).

			m.ip++;
		}

		// DISPENSE
		// disp
		// 16-bit type
		// opcode, r0, null, mode 
		// disp r0 # r0 contains value to dispense
		void disp(ref Instruction i, ref Machine m)
		{
			// Simulation:
			//   - Dispense money.
			//	 - These would be handled through sytem
			//     GPIOs (general purpose IO).

			m.ip++;
		}

		// REG MOVE REG
		// Register to register move.rX<- rY
		// 16-bit type
		// opcode, rX, rY, na
		// regr r0, r1 # r0 <- r1
		void regr(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.regs[a] = m.regs[b];

			m.ip++;
		}

		// REG MOVE IMMEDIATE
		// Move immediate into register.If you want to move a 32 bit immediate, use hi/lo
		// instructions to get value into a register.
		// 32-bit type
		// opcode, rX, immediate
		// movi 12345  # rX <- immediate
		void regi(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.regs[a] = int.Parse(b);

			m.ip++;
		}

		// REG MOVE HIGH
		// high(rX) <- immediate.Immediate should be 16 bits.
		// 32-bit type
		// 6 opcode, rX, immediate
		// regh r0, 1234 # high 16-bits set to 1234
		void regh(ref Instruction i, ref Machine m)
		{
			int immediate = int.Parse(i.field[1]);

			m.regs[i.field[0]] &= (immediate << 16) | 0xffff;

			m.ip++;
		}

		// REG MOVE LOW
		// low(rX) <- immediate.Immediate should be 16 bits.
		// 32-bit type
		// 6 opcode, rX, immediate
		// regl r0, 1234 # low 16-bits set to 1234
		void regl(ref Instruction i, ref Machine m)
		{
			int immediate = int.Parse(i.field[1]);

			m.regs[i.field[0]] &= immediate | (0xffff << 16);

			m.ip++;
		}

		// MEMORY MOVE: MEM TO REG
		// Memory to register move. rX <- *rY. rY must contain the memory address which
		// to move from. First put the addres into rY. Then issues the regm instruction
		// which knows how to access memory.
		// 16-bit type
		// opcode, rX, rY, null
		// regm rX, rY   # move memory pointed to by rY into rX.
		void memr(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.regs[a] = m.mem[int.Parse(b)];

			m.ip++;
		}

		// MEMORY MOVE: REG TO MEM
		// 16-bit type
		// opcode, rX, rY, null
		// rX contains memory location.rY contains value to move to that location.
		//   regi rY, 100 # move value into rY
		//   regi rX, immediate memory address
		// memm rX, rY   # move value rY into memory location pointed to by rX.
		void memm(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.mem[int.Parse(a)] = m.mem[int.Parse(b)];

			m.ip++;
		}

		// ADD
		// 16-bit type
		// opcode 6, rX, rY, na
		// rX = rX + rY
		void addr(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.regs[a] = m.regs[a] + m.regs[b];

			m.ip++;
		}

		// SUBTRACT
		// 16-bit type
		// opcode, rX, rY, null
		// rY = rY - rX
		void subr(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.regs[a] = m.regs[a] - m.regs[b];

			m.ip++;
		}

		// MULTIPLY
		// 16-bit type
		// opcode, rX, rY, null
		// rY = rY * rX
		void mulr(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.regs[a] = m.regs[a] * m.regs[b];

			m.ip++;
		}

		// DIVIDE
		// 16-bit type
		// opcode, rX, rY, null
		// rY = rY / rX
		void divr(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.regs[a] = m.regs[a] / m.regs[b];

			m.ip++;
		}

		// MOD
		// 16-bit type
		// opcode, rX, rY, null
		// rY = rY % rX
		void modr(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.regs[a] = m.regs[a] % m.regs[b];

			m.ip++;
		}

		// SHIFT LEFT
		// 16-bit type
		// opcode, rX, rY, null
		// rX = rX << rY
		void shl(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.regs[a] = m.regs[a] << m.regs[b];

			m.ip++;
		}

		// SHIFT RIGHT
		// 16-bit type
		// opcode, rX, rY, null
		// rX = rX >> rY
		void shr(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.regs[a] = m.regs[a] >> m.regs[b];

			m.ip++;
		}

		// AND
		// Bitwise And
		// 16-bit type
		// opcode, rX, rY, na
		//   rX = rX & rY
		void and(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.regs[a] = m.regs[a] & m.regs[b];

			m.ip++;
		}

		// OR
		// Bitwise Or
		// 16-bit type
		// opcode, rX, rY, na
		// rX = rX | rY
		void or(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.regs[a] = m.regs[a] | m.regs[b];

			m.ip++;
		}

		// JUMP
		// Jump to an address placed into rX
		// 16-bit type
		// opcode, rX, na, na
		// jmp rX # jump to address in rX
		void jmp(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];

			m.ip = m.labels[a];
		}


		// BRANCH
		// Branch to an address placed into rX
		// 16-bit type
		// opcode, rX, na, na
		// br rX # branch to address in rX
		void br(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];

			m.ip = m.labels[a];
		}

		// BRANCH LESS THAN
		// Branch to an address placed into rX if less than flag is set.
		// 16-bit type
		// opcode 6, rX, na, na
		// 
		void bls(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];

			if (m.compare == 1)
			{
				m.ip = m.labels[a];
			}
		}

		// BRANCH LESS THAN EQUAL
		// Branch to an address placed into rX if less than flag is set.
		// 16-bit type
		// opcode, rX, na, na
		// 
		void ble(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];

			if ((m.compare == 0) || (m.compare == 1))
			{
				m.ip = m.labels[a];
			}
		}

		// BRANCH LESS THAN EQUAL
		// Branch to an address placed into rX if greater than flag is set.
		// 16-bit type
		// opcode, rX, na, na
		//
		void bge(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];

			if (m.compare == 2)
			{
				m.ip = m.labels[a];
			}
		}

		// COMPARE
		// Compare rX and rY.CMPR register.
		// opcode 6, rX, rY, na
		//   rX == rY, equal bit; cmpr = 0x1
		//   rX >  rY, greater than bit set; cmpr = 0x2
		//   rX<rY, less than bit is set; cmpr = 0x3
		//   rX >= rY, greater than equal bit is set; cmpr = 0x4
		//   rX <= rY, less than equal bit is set; cmpr = 0x5
		void cmp(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			if (m.regs[a] == m.regs[b]) m.compare = 1;
			else if (m.regs[a] < m.regs[b]) m.compare = 2;
			else if (m.regs[a] > m.regs[b]) m.compare = 3;
			else if (m.regs[a] <= m.regs[b]) m.compare = 4;
			else if (m.regs[a] >= m.regs[b]) m.compare = 5;

			m.ip++;
		}

		// RANDOM
		// Random 22 bit number placed in rX.
		// 16-bit type
		// opcode, rX, na, na
		void rand(ref Instruction i, ref Machine m)
		{
			Random r = new Random();
			int random = r.Next(100);

			m.regs["r0"] = random;

			m.ip++;
		}

		int opcode(string i)
		{
			int opcode = 0;

			switch (i)
			{
				case "rst":
					opcode = 1;
					break;
				case "rbt":
					opcode = 2;
					break;
				case "halt":
					opcode = 3;
					break;
				case "off":
					opcode = 4;
					break;
				case "bccl":
					opcode = 5;
					break;
				case "bctg":
					opcode = 6;
					break;
				case "log":
					opcode = 7;
					break;
				case "ding":
					opcode = 8;
					break;
				case "vols":
					opcode = 9;
					break;
				case "crda":
					opcode = 10;
					break;
				case "crdc":
					opcode = 11;
					break;
				case "crdb":
					opcode = 12;
					break;
				case "bkpy":
					opcode = 13;
					break;
				case "bkbl":
					opcode = 14;
					break;
				case "bkad":
					opcode = 15;
					break;
				case "bkcl":
					opcode = 16;
					break;
				case "jpot":
					opcode = 17;
					break;
				case "pull":
					opcode = 18;
					break;
				case "btpl":
					opcode = 19;
					break;
				case "spin":
					opcode = 20;
					break;
				case "strt":
					opcode = 21;
					break;
				case "wait":
					opcode = 22;
					break;
				case "end":
					opcode = 23;
					break;
				case "abrt":
					opcode = 24;
					break;
				case "whlv":
					opcode = 25;
					break;
				case "payf":
					opcode = 26;
					break;
				case "drwr":
					opcode = 27;
					break;
				case "disp":
					opcode = 28;
					break;
				case "regr":
					opcode = 29;
					break;
				case "regi":
					opcode = 30;
					break;
				case "regh":
					opcode = 31;
					break;
				case "regl":
					opcode = 32;
					break;
				case "memr":
					opcode = 33;
					break;
				case "memm":
					opcode = 34;
					break;
				case "addr":
					opcode = 35;
					break;
				case "subr":
					opcode = 36;
					break;
				case "mulr":
					opcode = 37;
					break;
				case "divr":
					opcode = 38;
					break;
				case "modr":
					opcode = 39;
					break;
				case "shl":
					opcode = 40;
					break;
				case "shr":
					opcode = 41;
					break;
				case "and":
					opcode = 42;
					break;
				case "or":
					opcode = 43;
					break;
				case "jmp":
					opcode = 44;
					break;
				case "br":
					opcode = 45;
					break;
				case "bl":
					opcode = 46;
					break;
				case "ble":
					opcode = 47;
					break;
				case "bge":
					opcode = 48;
					break;
				case "cmp":
					opcode = 49;
					break;
				case "rand":
					opcode = 50;
					break;
				default:
					break;
			}

			return opcode;
		}
	}
}
