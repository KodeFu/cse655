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
			if (i.instruction == String.Empty) return;

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
				case "bclr":
					bclr(ref i, ref m);
					break;
				case "beac":
					beac(ref i, ref m);
					break;
				case "log":
					log(ref i, ref m);
					break;
				case "loge":
					loge(ref i, ref m);
					break;
				case "ding":
					ding(ref i, ref m);
					break;
				case "volm":
					volm(ref i, ref m);
					break;
				case "txt":
					txt(ref i, ref m);
					break;
				case "clr":
					clr(ref i, ref m);
					break;
				case "insc":
					insc(ref i, ref m);
					break;
				case "insb":
					insb(ref i, ref m);
					break;
				case "pay":
					pay(ref i, ref m);
					break;
				case "bal":
					bal(ref i, ref m);
					break;
				case "jpot":
					jpot(ref i, ref m);
					break;
				case "pull":
					pull(ref i, ref m);
					break;
				case "btnp1":
					btnp1(ref i, ref m);
					break;
				case "btnp2":
					btnp2(ref i, ref m);
					break;
				case "btnp3":
					btnp3(ref i, ref m);
					break;
				case "spin":
					spin(ref i, ref m);
					break;
				case "stop":
					stop(ref i, ref m);
					break;
				case "wait":
					wait(ref i, ref m);
					break;
				case "wpos":
					wpos(ref i, ref m);
					break;
				case "winf":
					winf(ref i, ref m);
					break;
				case "payf":
					payf(ref i, ref m);
					break;
				case "pbck":
					pbck(ref i, ref m);
					break;
				case "regr":
					regr(ref i, ref m);
					break;
				case "regi":
					regi(ref i, ref m);
					break;
				case "regf":
					regf(ref i, ref m);
					break;
				case "memr":
					memr(ref i, ref m);
					break;
				case "memm":
					memm(ref i, ref m);
					break;
				case "memi":
					memi(ref i, ref m);
					break;
				case "br":
					br(ref i, ref m);
					break;
				case "bls":
					bls(ref i, ref m);
					break;
				case "blse":
					blse(ref i, ref m);
					break;
				case "bgr":
					bgr(ref i, ref m);
					break;
				case "bgre":
					bgre(ref i, ref m);
					break;
				case "jmp":
					jmp(ref i, ref m);
					break;
				case "cmp":
					cmp(ref i, ref m);
					break;
				case "rand":
					rand(ref i, ref m);
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
				case "addf":
					addf(ref i, ref m);
					break;
				case "subf":
					subf(ref i, ref m);
					break;
				case "divf":
					divf(ref i, ref m);
					break;
				case "mulf":
					mulf(ref i, ref m);
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

		void bclr(ref Instruction i, ref Machine m)
		{
			m.beaconColor = m.regs["r0"];
		}

		void beac(ref Instruction i, ref Machine m)
		{
			m.beacon = m.regs["r0"];
		}

		void log(ref Instruction i, ref Machine m)
		{
			m.error = m.regs["r0"];
		}

		void loge(ref Instruction i, ref Machine m)
		{
			m.error = m.regs["r0"];
			m.errorExt = m.regs["r1"];
		}

		void ding(ref Instruction i, ref Machine m)
		{
			m.ding = m.regs["r0"];
		}

		void volm(ref Instruction i, ref Machine m)
		{
			m.volume = m.regs["r0"];
		}

		void txt(ref Instruction i, ref Machine m)
		{
			// copy some text
		}

		void clr(ref Instruction i, ref Machine m)
		{
			// clear some text
		}

		void insc(ref Instruction i, ref Machine m)
		{
			// clear some credits
		}
		void insb(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void pay(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void bal(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void jpot(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void pull(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void btnp1(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void btnp2(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void btnp3(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void spin(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void stop(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void wait(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void wpos(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void winf(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void payf(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void pbck(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void regr(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.regs[a] = m.regs[b];
		}
		void regi(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.regs[a] = int.Parse(b);
		}
		void regf(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.floats[a] = float.Parse(b);
		}
		void memr(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.regs[a] = m.mem[int.Parse(b)];
		}
		void memm(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];

			m.mem[int.Parse(a)] = m.mem[int.Parse(b)];
		}
		void memi(ref Instruction i, ref Machine m)
		{
			string a = i.field[0];
			string b = i.field[1];
			
			m.mem[m.regs[a]] = int.Parse(b);
		}
		void br(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void bls(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void blse(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void bgr(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void bgre(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void jmp(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void cmp(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void rand(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void addr(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void subr(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void mulr(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void divr(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void addf(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void subf(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void divf(ref Instruction i, ref Machine m)
		{
			// clear some text
		}
		void mulf(ref Instruction i, ref Machine m)
		{
			m.regs["r0"] = m.regs["r0"] * m.regs["r1"];

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
