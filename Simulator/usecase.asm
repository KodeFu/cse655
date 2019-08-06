# usecase.asm
#   This is an example source file which shows a typical use case.
# 
# Author:
#   Mudit Vats

start:
        crda            2              # add two credits
        pull            2              # pull handle with two credits
        strt                           # start the gameplay session
        spin            r2             # spin the wheels; r2 is win/loss
        wait            1              # wait for spin completion
        end                            # end the gameplay session

        regi            r1, 1          # move 1 ("win") into r1
        cmp             r1, r2         # compare r1 to r2 (spin results)
        be              payout         # if equal, branch to payout
        br              done           # didn't win, done

payout:
        payf            r5             # get payout factor
        crdb            r6             # get credit balance
        mulr            r5, r6         # credit * payf => winings
        disp            r5             # dispense credits

done:                                  # fininshed game!
