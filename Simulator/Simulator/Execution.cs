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
					rst(ref m);
					break;
				case "rbt":
					rbt(ref m);
					break;
				case "halt":
					halt(ref m);
					break;
				case "off":
					off(ref m);
					break;
				case "bclr":
					bclr(ref m);
					break;
				case "beac":
					beac(ref m);
					break;
				case "log":
					log(ref m);
					break;
				case "loge":
					loge(ref m);
					break;
				case "ding":
					ding(ref m);
					break;
				case "volm":
					volm(ref m);
					break;
				case "txt":
					txt(ref m);
					break;
				case "clr":
					clr(ref m);
					break;
				case "insc":
					insc(ref m);
					break;
				case "insb":
					insb(ref m);
					break;
				case "pay":
					pay(ref m);
					break;
				case "bal":
					bal(ref m);
					break;
				case "jpot":
					jpot(ref m);
					break;
				case "pull":
					pull(ref m);
					break;
				case "btnp1":
					btnp1(ref m);
					break;
				case "btnp2":
					btnp2(ref m);
					break;
				case "btnp3":
					btnp3(ref m);
					break;
				case "spin":
					spin(ref m);
					break;
				case "stop":
					stop(ref m);
					break;
				case "wait":
					wait(ref m);
					break;
				case "wpos":
					wpos(ref m);
					break;
				case "winf":
					winf(ref m);
					break;
				case "payf":
					payf(ref m);
					break;
				case "pbck":
					pbck(ref m);
					break;
				case "regr":
					regr(ref m);
					break;
				case "regi":
					regi(ref m);
					break;
				case "memr":
					memr(ref m);
					break;
				case "memm":
					memm(ref m);
					break;
				case "memi":
					memi(ref m);
					break;
				case "br":
					br(ref m);
					break;
				case "bls":
					bls(ref m);
					break;
				case "blse":
					blse(ref m);
					break;
				case "bgr":
					bgr(ref m);
					break;
				case "bgre":
					bgre(ref m);
					break;
				case "jmp":
					jmp(ref m);
					break;
				case "cmp":
					cmp(ref m);
					break;
				case "rand":
					rand(ref m);
					break;
				case "addr":
					addr(ref m);
					break;
				case "subr":
					subr(ref m);
					break;
				case "mulr":
					mulr(ref m);
					break;
				case "divr":
					divr(ref m);
					break;
				case "addf":
					addf(ref m);
					break;
				case "subf":
					subf(ref m);
					break;
				case "divf":
					divf(ref m);
					break;
				case "mulf":
					mulf(ref m);
					break;
			}
		}

		void rst(ref Machine m)
		{
			m.Initialize();
		}

		void rbt(ref Machine m)
		{
			m.Initialize();
		}

		void halt(ref Machine m)
		{
			m.halt = 1;
		}

		void off(ref Machine m)
		{
			m.halt = 1;
		}

		void bclr(ref Machine m)
		{
			m.beaconColor = m.regs["r0"];
		}

		void beac(ref Machine m)
		{
			m.beacon = m.regs["r0"];
		}

		void log(ref Machine m)
		{
			m.error = m.regs["r0"];
		}

		void loge(ref Machine m)
		{
			m.error = m.regs["r0"];
			m.errorExt = m.regs["r1"];
		}

		void ding(ref Machine m)
		{
			m.ding = m.regs["r0"];
		}

		void volm(ref Machine m)
		{
			m.volume = m.regs["r0"];
		}

		void txt(ref Machine m)
		{
			// copy some text
		}

		void clr(ref Machine m)
		{
			// clear some text
		}

		void insc(ref Machine m)
		{
			// clear some text
		}
		void insb(ref Machine m)
		{
			// clear some text
		}
		void pay(ref Machine m)
		{
			// clear some text
		}
		void bal(ref Machine m)
		{
			// clear some text
		}
		void jpot(ref Machine m)
		{
			// clear some text
		}
		void pull(ref Machine m)
		{
			// clear some text
		}
		void btnp1(ref Machine m)
		{
			// clear some text
		}
		void btnp2(ref Machine m)
		{
			// clear some text
		}
		void btnp3(ref Machine m)
		{
			// clear some text
		}
		void spin(ref Machine m)
		{
			// clear some text
		}
		void stop(ref Machine m)
		{
			// clear some text
		}
		void wait(ref Machine m)
		{
			// clear some text
		}
		void wpos(ref Machine m)
		{
			// clear some text
		}
		void winf(ref Machine m)
		{
			// clear some text
		}
		void payf(ref Machine m)
		{
			// clear some text
		}
		void pbck(ref Machine m)
		{
			// clear some text
		}
		void regr(ref Machine m)
		{
			// clear some text
		}
		void regi(ref Machine m)
		{
			// clear some text
		}
		void memr(ref Machine m)
		{
			// clear some text
		}
		void memm(ref Machine m)
		{
			// clear some text
		}
		void memi(ref Machine m)
		{
			// clear some text
		}
		void br(ref Machine m)
		{
			// clear some text
		}
		void bls(ref Machine m)
		{
			// clear some text
		}
		void blse(ref Machine m)
		{
			// clear some text
		}
		void bgr(ref Machine m)
		{
			// clear some text
		}
		void bgre(ref Machine m)
		{
			// clear some text
		}
		void jmp(ref Machine m)
		{
			// clear some text
		}
		void cmp(ref Machine m)
		{
			// clear some text
		}
		void rand(ref Machine m)
		{
			// clear some text
		}
		void addr(ref Machine m)
		{
			// clear some text
		}
		void subr(ref Machine m)
		{
			// clear some text
		}
		void mulr(ref Machine m)
		{
			// clear some text
		}
		void divr(ref Machine m)
		{
			// clear some text
		}
		void addf(ref Machine m)
		{
			// clear some text
		}
		void subf(ref Machine m)
		{
			// clear some text
		}
		void divf(ref Machine m)
		{
			// clear some text
		}
		void mulf(ref Machine m)
		{
			// clear some text
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
