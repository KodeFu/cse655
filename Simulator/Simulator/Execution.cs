using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
	public class Execution
	{
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
				case "br":
					br(ref i, ref m);
					break;
				case "bri":
					bri(ref i, ref m);
					break;
				case "bls":
					bls(ref i, ref m);
					break;
				case "blsi":
					blsi(ref i, ref m);
					break;
				case "ble":
					ble(ref i, ref m);
					break;
				case "blei":
					blei(ref i, ref m);
					break;
				case "bge":
					bge(ref i, ref m);
					break;
				case "bgei":
					bgei(ref i, ref m);
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

		void rst(ref Instruction i, ref Machine m)
		{
			m.Initialize();
		}

		void rbt(ref Instruction i, ref Machine m)
		{
			m.Initialize();
		}

		void halt(ref Instruction i, ref Machine m)
		{
			m.halt = 1;
		}

		void off(ref Instruction i, ref Machine m)
		{
			m.halt = 1;
		}

		void bccl(ref Instruction i, ref Machine m)
		{
			m.beaconColor = m.regs["r0"];
			
			m.ip++;
		}

		void bctg(ref Instruction i, ref Machine m)
		{
			m.beacon = m.regs["r0"];

			m.ip++;
		}

		void log(ref Instruction i, ref Machine m)
		{
			m.error = m.regs["r0"];

			m.ip++;
		}

		void ding(ref Instruction i, ref Machine m)
		{
			m.ding = m.regs["r0"];

			m.ip++;
		}

		void vols(ref Instruction i, ref Machine m)
		{
			m.volume = m.regs["r0"];

			m.ip++;
		}

		void crda(ref Instruction i, ref Machine m)
		{
			m.credits = m.regs["r0"];

			m.ip++;
		}

		void crdc(ref Instruction i, ref Machine m)
		{
			int amount = m.regs["r0"];
			m.credits -= amount;

			m.regs["r0"] = m.credits;

			m.ip++;
		}

		void crdb(ref Instruction i, ref Machine m)
		{
			//m.credits = m.regs["r0"];

			m.ip++;
		}

		void bkpy(ref Instruction i, ref Machine m)
		{
			// clear some text
		}

		void bkbl(ref Instruction i, ref Machine m)
		{
			m.regs["r0"] = m.credits;

			m.ip++;
		}

		void bkad(ref Instruction i, ref Machine m)
		{
			// clear some text
		}

		void bkcl(ref Instruction i, ref Machine m)
		{
			// clear some text
		}

		void jpot(ref Instruction i, ref Machine m)
		{
			m.regs["r0"] = m.credits;

			m.credits = 0;

			m.ip++;
		}
		void pull(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void btnp(ref Instruction i, ref Machine m)
		{
			// clear some text
		}

		void spin(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void strt(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void wait(ref Instruction i, ref Machine m)
		{
			// clear some text
		}

		void end(ref Instruction i, ref Machine m)
		{
			// clear some text
		}

		void abrt(ref Instruction i, ref Machine m)
		{
			// clear some text
		}

		void whlv(ref Instruction i, ref Machine m)
		{
			// clear some text
		}

		void payf(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void drwr(ref Instruction i, ref Machine m)
		{
			// clear some text
		}

		void disp(ref Instruction i, ref Machine m)
		{
			// clear some text
		}

		void regr(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.regs[a] = m.regs[b];

			m.ip++;
		}
		void regi(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.regs[a] = int.Parse(b);

			m.ip++;
		}

		void regh(ref Instruction i, ref Machine m)
		{
		}

		void regl(ref Instruction i, ref Machine m)
		{
		}

		void memr(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.regs[a] = m.mem[int.Parse(b)];

			m.ip++;
		}
		void memm(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.mem[int.Parse(a)] = m.mem[int.Parse(b)];

			m.ip++;
		}

		void addr(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.regs[a] = m.regs[a] + m.regs[b];

			m.ip++;
		}
		void subr(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.regs[a] = m.regs[a] - m.regs[b];

			m.ip++;
		}
		void mulr(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.regs[a] = m.regs[a] * m.regs[b];

			m.ip++;
		}
		void divr(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.regs[a] = m.regs[a] / m.regs[b];

			m.ip++;
		}

		void modr(ref Instruction i, ref Machine m)
		{
			
		}

		void shl(ref Instruction i, ref Machine m)
		{

		}

		void shr(ref Instruction i, ref Machine m)
		{

		}

		void and(ref Instruction i, ref Machine m)
		{

		}

		void or(ref Instruction i, ref Machine m)
		{

		}

		void br(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];

			m.ip = m.labels[a];
		}

		void bri(ref Instruction i, ref Machine m)
		{

		}

		void bls(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];

			if (m.compare == 1)
			{
				m.ip = m.labels[a];
			}
		}

		void blsi(ref Instruction i, ref Machine m)
		{
		
		}

		void ble(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];

			if ((m.compare == 0) || (m.compare == 1))
			{
				m.ip = m.labels[a];
			}
		}

		void blei(ref Instruction i, ref Machine m)
		{

		}

		void bge(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];

			if (m.compare == 2)
			{
				m.ip = m.labels[a];
			}
		}

		void bgei(ref Instruction i, ref Machine m)
		{

		}


		void bgre(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];

			if ((m.compare == 0) || (m.compare == 2))
			{
				m.ip = m.labels[a];
			}
		}
		void jmp(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
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
				case "br":
					opcode = 44;
					break;
				case "bri":
					opcode = 45;
					break;
				case "bl":
					opcode = 46;
					break;
				case "bli":
					opcode = 47;
					break;
				case "ble":
					opcode = 48;
					break;
				case "blei":
					opcode = 49;
					break;
				case "bge":
					opcode = 50;
					break;
				case "bgei":
					opcode = 51;
					break;
				case "cmp":
					opcode = 52;
					break;
				case "rand":
					opcode = 53;
					break;
				default:
					break;
			}

			return opcode;
		}
	}
}

/*

Regs
$log level
$beac on/off
$cred num
halt  0/1

3  loglevel	7 (5=log everything, 3=warn, 1=error)
2  beacon color green
1  beacon state off
32 coin 0
32 bill 0


 * 	# Manageability
	rst					Reset machine, default values
	rbt					Reboot machine
	halt				Halt machine - stop it, but don't turn off
	off					Turn off machine - turn off
4

	# Beacon
	bclr	r0			Set bacon color
	beac	r0			Turn on / off, 0=off, 1=on
	log		r0			Code
	loge	r0, r1		Code + value

5
	
	# Audio
	ding	r0			Ding r0 times
	volm	r0			0-100;
2
	
	# Text Display
	txt		r0			r0 is address of text
	clr					clear display
2
	
	# Coin
	insc	#25			Add coin, 25 cents, example.
	insb	#1			Add bill, 1 dollar
	pay		#amount		Pay out amount via dispenser
	bal		$r0			Get local balance
	jpot				Dispense all money
5

	# Handles / Buttons
	pull				Handle pulled down
	btnp1	#play		Button pull down, #play1
	btnp2	#play		Button pull down, #play2
	btnp3	#play		Button pull down, #play3
4
	
	spin	r0			Spin wheel; r0 has wheel number (0, 1, 2)
	stop	r0			wheels, r0, r1, r2 contain reel position; r0 has wheel number (0, 1, 2)
	wait	r0			Wait value, for spin. r0 is wait time seconds
	wpos	r0, r1		Get wheel position (wheel 1, 2, 3)
	winf	r0			Put wheel 1, 2, 3 into r0-r2, return winf
5

	# Payment
	payf	r0, r1		Calculate payback factor, r0 is plays (1, 2, 3); r1 factor
	pbck	r0, r1		Calculate payback, r0 is factor, r1 is amount
2	
	# Core ASM
	regr	r0, r0		Move register to register
	regi	r0, imm		Move immediate to register
	memr	r0, mem		Move memory to register
	memm	mem, r0		Move memory to register
	memi	mem, imm	Move immediate into register
4	
	br		label		Branch to label
	bls		label		Branch less than
	blse	label		Branch less than equal
	bgr		label		Branch greater then
	bgre	label		Brance greater than equal
	jmp		label		Jump to a label
	cmp		r0, r1		result go into comp register 0=equal, 1=lt, 2=gt
7

	rand	r0			get random number
	addr	r0, r1		r0 + r1 => r0
	subr	r0, r1		r0 - r1 => r0
	mulr	r0, r1		r0 * r1 => r0
	divr	r0, r1		r0 / r1 => r3 quotient = r4 remainder
	addf	f0, f1		f0 + f1 => f0
	subf	f0, f1		f0 - f1 => f0
	divf	r0, r1		f0 / f1 => f0
	mulf	f0, f1		f0 * f1 => f0
9
*/
