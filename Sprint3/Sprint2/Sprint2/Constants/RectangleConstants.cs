using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2.Constants
{
    public class Rec
    {
        /*
         * Background Items
         */
        //Black.cs
        public const int BLACK_X = 12;
        public const int BLACK_Y = 22;
        public const int BLACK_W = 1;
        public const int BLACK_H = 1;

        //Bush1.cs
        public const int BUSH1_X = 376;
        public const int BUSH1_Y = 184;
        public const int BUSH1_W = 32;
        public const int BUSH1_H = 16;

        //Bush2.cs
        public const int BUSH2_X = 664;
        public const int BUSH2_Y = 184;
        public const int BUSH2_W = 48;
        public const int BUSH2_H = 16;

        //Bush3.cs
        public const int BUSH3_X = 184;
        public const int BUSH3_Y = 184;
        public const int BUSH3_W = 64;
        public const int BUSH3_H = 16;

        //Cloud1.cs
        public const int CLOUD1_X = 0;
        public const int CLOUD1_Y = 320;
        public const int CLOUD1_W = 47;
        public const int CLOUD1_H = 28;

        //Cloud2.cs
        public const int CLOUD2_X = 584;
        public const int CLOUD2_Y = 23;
        public const int CLOUD2_W = 48;
        public const int CLOUD2_H = 28;

        //Cloud3.cs
        public const int CLOUD3_X = 440;
        public const int CLOUD3_Y = 40;
        public const int CLOUD3_W = 64;
        public const int CLOUD3_H = 24;
        
        //Level1Castle.cs
        public const int CASTLE_X = 176;
        public const int CASTLE_Y = 413;
        public const int CASTLE_W = 80;
        public const int CASTLE_H = 80;

        /*
         * Enemies
         */
        //DeadGoomba.cs
        public const int DEADGOOMBA_X = 60;
        public const int DEADGOOMBA_Y = 8;
        public const int DEADGOOMBA_W = 16;
        public const int DEADGOOMBA_H = 8;

        //WalkingGoomba.cs
        public const int WALKINGGOOMBA_X0 = 0;
        public const int WALKINGGOOMBA_X1 = 30;
        public const int WALKINGGOOMBA_Y = 4;
        public const int WALKINGGOOMBA_W = 16;
        public const int WALKINGGOOMBA_H = 16;

        //LeftWalkingKoopa.cs
        public const int LWALKINGKOOPA_X0 = 150;
        public const int LWALKINGKOOPA_X1 = 180;
        public const int LWALKINGKOOPA_Y = 0;
        public const int LWALKINGKOOPA_W = 16;
        public const int LWALKINGKOOPA_H0 = 24;
        public const int LWALKINGKOOPA_H1 = 23;

        //RightWalkingKoopa.cs
        public const int RWALKINGKOOPA_X0 = 210;
        public const int RWALKINGKOOPA_X1 = 240;
        public const int RWALKINGKOOPA_Y = 0;
        public const int RWALKINGKOOPA_W = 16;
        public const int RWALKINGKOOPA_H0 = 23;
        public const int RWALKINGKOOPA_H1 = 24;

        //LeftWalkingKoopa.cs
        public const int SHELLKOOPA_X = 360;
        public const int SHELLKOOPA_Y = 5;
        public const int SHELLKOOPA_W = 16;
        public const int SHELLKOOPA_H = 14;

        /*
         * Blocks
         */
        public const int BLOCK_W = 16;
        public const int BLOCK_H = 16;

        //UnderworldBrickBlock.cs
        public const int UBRICKBLOCK_X = 32;
        public const int UBRICKBLOCK_Y = 32;

        //UnderworldFloorBlock.cs
        public const int UFLOORBLOCK_X = 0;
        public const int UFLOORBLOCK_Y = 32;

        //BrickBlock.cs && UnbreakableBrickBlock.cs && UsableBrickBlock
        public const int BRICKBLOCK_X = 32;
        public const int BRICKBLOCK_Y = 0;

        //FloorBlock.cs
        public const int FLOORBLOCK_X = 0;
        public const int FLOORBLOCK_Y = 0;

        //QuestionBlock.cs
        public const int QUESTIONBLOCK_X0 = 368;
        public const int QUESTIONBLOCK_X1 = 384;
        public const int QUESTIONBLOCK_X2 = 400;
        public const int QUESTIONBLOCK_Y= 0;

        //StepBlock.cs
        public const int STEPBLOCK_X = 0;
        public const int STEPBLOCK_Y = 16;

        //UsedBlock.cs && UsedQuestionBlock.cs
        public const int USEDBLOCK_X = 48;
        public const int USEDBLOCK_Y = 0;

        /*
         * DeadBodies
         */ 
        //DeadBodyGoomba.cs
        public const int DEADBODYGOOMBA_X = 0;
        public const int DEADBODYGOOMBA_Y = 4;
        public const int DEADBODYGOOMBA_W = 16;
        public const int DEADBODYGOOMBA_H = 16;

        //DeadBodyKoopa.cs
        public const int DEADBODYKOOPA_X = 360;
        public const int DEADBODYKOOPA_Y = 5;
        public const int DEADBODYKOOPA_W = 16;
        public const int DEADBODYKOOPA_H = 14;

        //DeadMario.cs
        public const int DEADMARIO_X = 13;
        public const int DEADMARIO_Y = 46;
        public const int DEADMARIO_W = 14;
        public const int DEADMARIO_H = 14;

        /*
         * Objects
         */
        //FireBall.cs
        public const int FIREBALL_X0 = 572;
        public const int FIREBALL_X1 = 580;
        public const int FIREBALL_Y0 = 144;
        public const int FIREBALL_Y1 = 152;
        public const int FIREBALL_W = 8;
        public const int FIREBALL_H = 8;

        //Flag.cs
        public const int FLAG_X = 253;
        public const int FLAG_Y = 320;
        public const int FLAG_W = 16;
        public const int FLAG_H = 16;

        //Pole.cs
        public const int POLE_X = 256;
        public const int POLE_Y = 341;
        public const int POLE_W = 8;
        public const int POLE_H = 152;

        /*
         * Items
         */
        //Coin.cs
        public const int COIN_X0 = 371;
        public const int COIN_X1 = 387;
        public const int COIN_X2 = 403;
        public const int COIN_Y = 18;
        public const int COIN_W = 10;
        public const int COIN_H = 14;

        //BlockCoins.cs
        public const int BLOCKCOIN_X0 = 480;
        public const int BLOCKCOIN_X1 = 496;
        public const int BLOCKCOIN_X2 = 512;
        public const int BLOCKCOIN_X3 = 528;
        public const int BLOCKCOIN_Y = 96;
        public const int BLOCKCOIN_W = 8;
        public const int BLOCKCOIN_H = 14;

        //FireFlower.cs
        public const int FIREFLOWER_X0 = 476;
        public const int FIREFLOWER_X1 = 492;
        public const int FIREFLOWER_X2 = 508;
        public const int FIREFLOWER_X3 = 524;
        public const int FIREFLOWER_Y = 32;
        public const int FIREFLOWER_W = 16;
        public const int FIREFLOWER_H = 16;

        //Mushroom.cs
        public const int MUSHROOM_X = 476;
        public const int MUSHROOM_Y = 16;
        public const int MUSHROOM_W = 16;
        public const int MUSHROOM_H = 16;

        //PoisonMushroom.cs
        public const int POISONMUSHROOM_X = 492;

        //Star.cs
        public const int STAR_X0 = 765;
        public const int STAR_X1 = 781;
        public const int STAR_X2 = 797;
        public const int STAR_X3 = 813;
        public const int STAR_Y = 48;
        public const int STAR_W = 14;
        public const int STAR_H = 16;

        /* 
         * PipeState
         */
        //Pipe.cs
        public const int PIPE_X = 0;
        public const int PIPE_Y = 128;
        public const int PIPE_W = 32;
        public const int PIPE_H = 32;

        //LeftFacingPipe.cs
        public const int LFPIPE_X = 32;
        public const int LFPIPE_Y = 160;
        public const int LFPIPE_W = 34;
        public const int LFPIPE_H = 32;

        //MediumPipe.cs
        public const int MPIPE_X = 176;
        public const int MPIPE_Y = 320;
        public const int MPIPE_W = 32;
        public const int MPIPE_H = 48;

        //ShortPipe.cs
        public const int SPIPE_X = 0;
        public const int SPIPE_Y = 128;
        public const int SPIPE_W = 32;
        public const int SPIPE_H = 32;

        //TallPipe.cs
        public const int TPIPE_X = 208;
        public const int TPIPE_Y = 320;
        public const int TPIPE_W = 32;
        public const int TPIPE_H = 64;

        //TallUndergroundPipe.cs
        public const int TUPIPE_X = 400;
        public const int TUPIPE_Y = 317;
        public const int TUPIPE_W = 28;
        public const int TUPIPE_H = 176;

        /*
         * MarioStates
         */
        //bigLeftFacingCrouching.cs && bigRightFacingCrouching.cs
        public const int BLFCROUCHING_X = 220;
        public const int BRFCROUCHING_X = 277;

        public const int BIGCROUCHING_Y = 11;
        public const int BIGCROUCHING_W = 16;
        public const int BIGCROUCHING_H = 22;

        //bigLeftFacingFlagPole.cs && bigRightFacingFlagPole.cs
        public const int BLFFLAGPOLE_X = 94;
        public const int BRFFLAGPOLE_X = 405;

        public const int BIGFLAGPOLE_Y = 6;
        public const int BIGFLAGPOLE_W = 14;
        public const int BIGFLAGPOLE_H = 27;

        //bigLeftFacingIdle.cs && bigRightFacingIdle.cs
        public const int BLFIDLE_X = 239;
        public const int BRFIDLE_X = 258;

        public const int BIGIDLE_Y = 1;
        public const int BIGIDLE_W = 16;
        public const int BIGIDLE_H = 32;

        //bigLeftFacingJumping.cs && bigRightFacingJumping.cs 
        public const int BLFJUMPING_X = 128;
        public const int BRFJUMPING_X = 369;

        public const int BIGJUMPING_Y = 2;
        public const int BIGJUMPING_W = 16;
        public const int BIGJUMPING_H = 31;

        //bigLeftFacingRunning.cs && bigRightFacingRunning.cs
        public const int BLFRUNNING_X0 = 201;
        public const int BLFRUNNING_X1 = 184;
        public const int BLFRUNNING_X2 = 166;
       
        public const int BRFRUNNING_X0 = 296;
        public const int BRFRUNNING_X1 = 315;
        public const int BRFRUNNING_X2 = 331;

        public const int BIGRUNNING_Y0 = 3;
        public const int BIGRUNNING_Y1 = 2;
        public const int BIGRUNNING_Y2 = 1;

        public const int BIGRUNNING_W0 = 16;
        public const int BIGRUNNING_W1 = 14;
        public const int BIGRUNNING_W2 = 16;

        public const int BIGRUNNING_H0 = 30;
        public const int BIGRUNNING_H1 = 31;
        public const int BIGRUNNING_H2 = 32;


    }
}
