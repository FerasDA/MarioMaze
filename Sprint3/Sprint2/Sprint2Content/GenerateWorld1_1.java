import java.io.IOException;
import java.io.PrintWriter;

public class GenerateWorld1_1 {

    public static void main(String[] args) throws IOException {
        PrintWriter writer = new PrintWriter("LevelData1.xml");

        printHeader(writer);

        printBackgrounds(writer);
        printBlocks(writer);
        printEnemies(writer);
        printItems(writer);
        printPipes(writer);
        printFlagPole(writer);
        printPlayers(writer);

        printCloser(writer);

        writer.close();
    }

    private static void printHeader(PrintWriter writer) {
        writer.println("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
        writer.println("<XnaContent>");
        writer.println("  <Asset Type=\"DataTypes.Levels\">");
    }

    private static void printCloser(PrintWriter writer) {
        writer.println("  </Asset>");
        writer.println("</XnaContent>");

    }

    private static void printBackgrounds(PrintWriter writer) {
        writer.println("    <backgrounds>");

        // clouds
        // cloud 1
        writer.println("      <Item>");
        writer.println("        <name>Cloud1</name>");
        writer.println("        <PosX>136</PosX>");
        writer.println("        <PosY>312</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Cloud1</name>");
        writer.println("        <PosX>312</PosX>");
        writer.println("        <PosY>296</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Cloud1</name>");
        writer.println("        <PosX>904</PosX>");
        writer.println("        <PosY>312</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Cloud1</name>");
        writer.println("        <PosX>1080</PosX>");
        writer.println("        <PosY>296</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Cloud1</name>");
        writer.println("        <PosX>1672</PosX>");
        writer.println("        <PosY>312</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Cloud1</name>");
        writer.println("        <PosX>1848</PosX>");
        writer.println("        <PosY>296</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Cloud1</name>");
        writer.println("        <PosX>2440</PosX>");
        writer.println("        <PosY>312</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Cloud1</name>");
        writer.println("        <PosX>2616</PosX>");
        writer.println("        <PosY>296</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Cloud1</name>");
        writer.println("        <PosX>3208</PosX>");
        writer.println("        <PosY>312</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Cloud1</name>");
        writer.println("        <PosX>3384</PosX>");
        writer.println("        <PosY>296</PosY>");
        writer.println("      </Item>");
        // cloud 2
        writer.println("      <Item>");
        writer.println("        <name>Cloud2</name>");
        writer.println("        <PosX>584</PosX>");
        writer.println("        <PosY>296</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Cloud2</name>");
        writer.println("        <PosX>1352</PosX>");
        writer.println("        <PosY>296</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Cloud2</name>");
        writer.println("        <PosX>2120</PosX>");
        writer.println("        <PosY>296</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Cloud2</name>");
        writer.println("        <PosX>2888</PosX>");
        writer.println("        <PosY>296</PosY>");
        writer.println("      </Item>");

        // cloud 3
        writer.println("      <Item>");
        writer.println("        <name>Cloud3</name>");
        writer.println("        <PosX>440</PosX>");
        writer.println("        <PosY>312</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Cloud3</name>");
        writer.println("        <PosX>1208</PosX>");
        writer.println("        <PosY>312</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Cloud3</name>");
        writer.println("        <PosX>1976</PosX>");
        writer.println("        <PosY>312</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Cloud3</name>");
        writer.println("        <PosX>2744</PosX>");
        writer.println("        <PosY>312</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Cloud3</name>");
        writer.println("        <PosX>3512</PosX>");
        writer.println("        <PosY>312</PosY>");
        writer.println("      </Item>");
        // end of clouds

        // bushes
        // bush 1
        writer.println("      <Item>");
        writer.println("        <name>Bush1</name>");
        writer.println("        <PosX>376</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Bush1</name>");
        writer.println("        <PosX>1144</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Bush1</name>");
        writer.println("        <PosX>1912</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Bush1</name>");
        writer.println("        <PosX>2520</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Bush1</name>");
        writer.println("        <PosX>2680</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Bush1</name>");
        writer.println("        <PosX>3288</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Bush1</name>");
        writer.println("        <PosX>3448</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        // bush 2
        writer.println("      <Item>");
        writer.println("        <name>Bush2</name>");
        writer.println("        <PosX>664</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Bush1</name>");
        writer.println("        <PosX>1432</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Bush1</name>");
        writer.println("        <PosX>2200</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");
        // bush 3

        writer.println("      <Item>");
        writer.println("        <name>Bush3</name>");
        writer.println("        <PosX>184</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Bush3</name>");
        writer.println("        <PosX>952</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Bush3</name>");
        writer.println("        <PosX>1720</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");
        // end of bushes

        // mountains
        // small
        writer.println("      <Item>");
        writer.println("        <name>SmallMountain</name>");
        writer.println("        <PosX>256</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>SmallMountain</name>");
        writer.println("        <PosX>1024</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>SmallMountain</name>");
        writer.println("        <PosX>1792</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>SmallMountain</name>");
        writer.println("        <PosX>2560</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>SmallMountain</name>");
        writer.println("        <PosX>3328</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");
        // big
        writer.println("      <Item>");
        writer.println("        <name>Mountains</name>");
        writer.println("        <PosX>0</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Mountains</name>");
        writer.println("        <PosX>768</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Mountains</name>");
        writer.println("        <PosX>1536</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Mountains</name>");
        writer.println("        <PosX>2304</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Mountains</name>");
        writer.println("        <PosX>3072</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");
        // end of mountains

        // castle 1
        writer.println("      <Item>");
        writer.println("        <name>Castle1</name>");
        writer.println("        <PosX>3232</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        // black background for underworld

        writer.println("      <Item>");
        writer.println("        <name>Black</name>");
        writer.println("        <PosX>5000</PosX>");
        writer.println("        <PosY>0</PosY>");
        writer.println("      </Item>");

        writer.println("    </backgrounds>");
    }

    private static void printBlocks(PrintWriter writer) {
        writer.println("    <blocks>");

        // floor blocks
        int x = 0;
        while (x < 1100) {
            writer.println("      <Item>");
            writer.println("        <name>FloorBlock</name>");
            writer.println("        <PosX>" + x + "</PosX>");
            writer.println("        <PosY>480</PosY>");
            writer.println("      </Item>");
            x += 16;
        }
        x = 0;
        while (x < 1100) {
            writer.println("      <Item>");
            writer.println("        <name>FloorBlock</name>");
            writer.println("        <PosX>" + x + "</PosX>");
            writer.println("        <PosY>464</PosY>");
            writer.println("      </Item>");
            x += 16;
        }

        x = 1136;
        while (x < 1370) {
            writer.println("      <Item>");
            writer.println("        <name>FloorBlock</name>");
            writer.println("        <PosX>" + x + "</PosX>");
            writer.println("        <PosY>480</PosY>");
            writer.println("      </Item>");
            x += 16;
        }
        x = 1136;
        while (x < 1370) {
            writer.println("      <Item>");
            writer.println("        <name>FloorBlock</name>");
            writer.println("        <PosX>" + x + "</PosX>");
            writer.println("        <PosY>464</PosY>");
            writer.println("      </Item>");
            x += 16;
        }

        x = 1424;
        while (x < 2440) {
            writer.println("      <Item>");
            writer.println("        <name>FloorBlock</name>");
            writer.println("        <PosX>" + x + "</PosX>");
            writer.println("        <PosY>480</PosY>");
            writer.println("      </Item>");
            x += 16;
        }
        x = 1424;
        while (x < 2440) {
            writer.println("      <Item>");
            writer.println("        <name>FloorBlock</name>");
            writer.println("        <PosX>" + x + "</PosX>");
            writer.println("        <PosY>464</PosY>");
            writer.println("      </Item>");
            x += 16;
        }

        x = 2480;
        while (x < 3590) {
            writer.println("      <Item>");
            writer.println("        <name>FloorBlock</name>");
            writer.println("        <PosX>" + x + "</PosX>");
            writer.println("        <PosY>480</PosY>");
            writer.println("      </Item>");
            x += 16;
        }
        x = 2480;
        while (x < 3590) {
            writer.println("      <Item>");
            writer.println("        <name>FloorBlock</name>");
            writer.println("        <PosX>" + x + "</PosX>");
            writer.println("        <PosY>464</PosY>");
            writer.println("      </Item>");
            x += 16;
        }
        // end of floor blocks

        // Brick Blocks
        writer.println("      <Item>");
        writer.println("        <name>BrickBlock</name>");
        writer.println("        <PosX>320</PosX>");
        writer.println("        <PosY>400</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>BrickBlock</name>");
        writer.println("        <PosX>352</PosX>");
        writer.println("        <PosY>400</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>BrickBlock</name>");
        writer.println("        <PosX>384</PosX>");
        writer.println("        <PosY>400</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>BrickBlock</name>");
        writer.println("        <PosX>1232</PosX>");
        writer.println("        <PosY>400</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>BrickBlock</name>");
        writer.println("        <PosX>1264</PosX>");
        writer.println("        <PosY>400</PosY>");
        writer.println("      </Item>");

        x = 1280;
        while (x < 1400) {
            writer.println("      <Item>");
            writer.println("        <name>BrickBlock</name>");
            writer.println("        <PosX>" + x + "</PosX>");
            writer.println("        <PosY>336</PosY>");
            writer.println("      </Item>");
            x += 16;
        }

        x = 1456;
        while (x < 1500) {
            writer.println("      <Item>");
            writer.println("        <name>BrickBlock</name>");
            writer.println("        <PosX>" + x + "</PosX>");
            writer.println("        <PosY>336</PosY>");
            writer.println("      </Item>");
            x += 16;
        }

        writer.println("      <Item>");
        writer.println("        <name>BrickBlock</name>");
        writer.println("        <PosX>1504</PosX>");
        writer.println("        <PosY>400</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>BrickBlock</name>");
        writer.println("        <PosX>1600</PosX>");
        writer.println("        <PosY>400</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>BrickBlock</name>");
        writer.println("        <PosX>1616</PosX>");
        writer.println("        <PosY>400</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>BrickBlock</name>");
        writer.println("        <PosX>1888</PosX>");
        writer.println("        <PosY>400</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>BrickBlock</name>");
        writer.println("        <PosX>1936</PosX>");
        writer.println("        <PosY>336</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>BrickBlock</name>");
        writer.println("        <PosX>1952</PosX>");
        writer.println("        <PosY>336</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>BrickBlock</name>");
        writer.println("        <PosX>1968</PosX>");
        writer.println("        <PosY>336</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>BrickBlock</name>");
        writer.println("        <PosX>2048</PosX>");
        writer.println("        <PosY>336</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>BrickBlock</name>");
        writer.println("        <PosX>2064</PosX>");
        writer.println("        <PosY>400</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>BrickBlock</name>");
        writer.println("        <PosX>2080</PosX>");
        writer.println("        <PosY>400</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>BrickBlock</name>");
        writer.println("        <PosX>2096</PosX>");
        writer.println("        <PosY>336</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>BrickBlock</name>");
        writer.println("        <PosX>2688</PosX>");
        writer.println("        <PosY>400</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>BrickBlock</name>");
        writer.println("        <PosX>2704</PosX>");
        writer.println("        <PosY>400</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>BrickBlock</name>");
        writer.println("        <PosX>2736</PosX>");
        writer.println("        <PosY>400</PosY>");
        writer.println("      </Item>");
        // end of brick blocks

        // Question blocks
        writer.println("      <Item>");
        writer.println("        <name>QuestionBlock</name>");
        writer.println("        <PosX>256</PosX>");
        writer.println("        <PosY>400</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>QuestionBlock</name>");
        writer.println("        <PosX>336</PosX>");
        writer.println("        <PosY>400</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>QuestionBlock</name>");
        writer.println("        <PosX>352</PosX>");
        writer.println("        <PosY>336</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>QuestionBlock</name>");
        writer.println("        <PosX>368</PosX>");
        writer.println("        <PosY>400</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>QuestionBlock</name>");
        writer.println("        <PosX>1248</PosX>");
        writer.println("        <PosY>400</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>QuestionBlock</name>");
        writer.println("        <PosX>1504</PosX>");
        writer.println("        <PosY>336</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>QuestionBlock</name>");
        writer.println("        <PosX>1696</PosX>");
        writer.println("        <PosY>400</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>QuestionBlock</name>");
        writer.println("        <PosX>1744</PosX>");
        writer.println("        <PosY>400</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>QuestionBlock</name>");
        writer.println("        <PosX>1744</PosX>");
        writer.println("        <PosY>336</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>QuestionBlock</name>");
        writer.println("        <PosX>1792</PosX>");
        writer.println("        <PosY>400</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>QuestionBlock</name>");
        writer.println("        <PosX>2064</PosX>");
        writer.println("        <PosY>336</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>QuestionBlock</name>");
        writer.println("        <PosX>2080</PosX>");
        writer.println("        <PosY>336</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>QuestionBlock</name>");
        writer.println("        <PosX>2720</PosX>");
        writer.println("        <PosY>400</PosY>");
        writer.println("      </Item>");
        // end of question blocks'

        // step blocks

        // 1rst step up
        x = 2144;
        while (x < 2200) {
            writer.println("      <Item>");
            writer.println("        <name>StepBlock</name>");
            writer.println("        <PosX>" + x + "</PosX>");
            writer.println("        <PosY>448</PosY>");
            writer.println("      </Item>");
            x += 16;
        }

        x = 2160;
        while (x < 2200) {
            writer.println("      <Item>");
            writer.println("        <name>StepBlock</name>");
            writer.println("        <PosX>" + x + "</PosX>");
            writer.println("        <PosY>432</PosY>");
            writer.println("      </Item>");
            x += 16;
        }

        x = 2176;
        while (x < 2200) {
            writer.println("      <Item>");
            writer.println("        <name>StepBlock</name>");
            writer.println("        <PosX>" + x + "</PosX>");
            writer.println("        <PosY>416</PosY>");
            writer.println("      </Item>");
            x += 16;
        }

        x = 2192;
        while (x < 2200) {
            writer.println("      <Item>");
            writer.println("        <name>StepBlock</name>");
            writer.println("        <PosX>" + x + "</PosX>");
            writer.println("        <PosY>400</PosY>");
            writer.println("      </Item>");
            x += 16;
        }
        // end of first step up

        // first step down

        int y;
        int yCount;

        y = 448;
        yCount = 0;
        while (y > 390) {
            x = 2240;
            while (x < 2300 - 16 * yCount) {
                writer.println("      <Item>");
                writer.println("        <name>StepBlock</name>");
                writer.println("        <PosX>" + x + "</PosX>");
                writer.println("        <PosY>" + y + "</PosY>");
                writer.println("      </Item>");
                x += 16;
            }
            y -= 16;
            yCount++;
        }

        // end of first step down

        // second step up
        x = 2368;
        while (x < 2440) {
            writer.println("      <Item>");
            writer.println("        <name>StepBlock</name>");
            writer.println("        <PosX>" + x + "</PosX>");
            writer.println("        <PosY>448</PosY>");
            writer.println("      </Item>");
            x += 16;
        }

        x = 2384;
        while (x < 2440) {
            writer.println("      <Item>");
            writer.println("        <name>StepBlock</name>");
            writer.println("        <PosX>" + x + "</PosX>");
            writer.println("        <PosY>432</PosY>");
            writer.println("      </Item>");
            x += 16;
        }

        x = 2400;
        while (x < 2440) {
            writer.println("      <Item>");
            writer.println("        <name>StepBlock</name>");
            writer.println("        <PosX>" + x + "</PosX>");
            writer.println("        <PosY>416</PosY>");
            writer.println("      </Item>");
            x += 16;
        }

        x = 2416;
        while (x < 2440) {
            writer.println("      <Item>");
            writer.println("        <name>StepBlock</name>");
            writer.println("        <PosX>" + x + "</PosX>");
            writer.println("        <PosY>400</PosY>");
            writer.println("      </Item>");
            x += 16;
        }
        // end of second step up

        // second step down

        y = 448;
        yCount = 0;
        while (y > 390) {
            x = 2480;
            while (x < 2540 - 16 * yCount) {
                writer.println("      <Item>");
                writer.println("        <name>StepBlock</name>");
                writer.println("        <PosX>" + x + "</PosX>");
                writer.println("        <PosY>" + y + "</PosY>");
                writer.println("      </Item>");
                x += 16;
            }
            y -= 16;
            yCount++;
        }

        // end of second step down

        // final steps

        y = 448;
        yCount = 0;
        while (y > 330) {
            x = 2896 + (16 * yCount);
            while (x < 3030) {
                writer.println("      <Item>");
                writer.println("        <name>StepBlock</name>");
                writer.println("        <PosX>" + x + "</PosX>");
                writer.println("        <PosY>" + y + "</PosY>");
                writer.println("      </Item>");
                x += 16;
            }
            y -= 16;
            yCount++;
        }

        // end of step blocks
        writer.println("      <Item>");
        writer.println("        <name>StepBlock</name>");
        writer.println("        <PosX>3168</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        // underworld brick blocks
        x = 6000;
        y = 448;
        while (y > 270) {
            writer.println("      <Item>");
            writer.println("        <name>UnderworldBrickBlock</name>");
            writer.println("        <PosX>" + x + "</PosX>");
            writer.println("        <PosY>" + y + "</PosY>");
            writer.println("      </Item>");
            y -= 16;
        }

        y = 448;
        while (y > 270) {
            x = 6064;
            if ((y > 400) || (y < 290)) {
                while (x < 6170) {
                    writer.println("      <Item>");
                    writer.println("        <name>UnderworldBrickBlock</name>");
                    writer.println("        <PosX>" + x + "</PosX>");
                    writer.println("        <PosY>" + y + "</PosY>");
                    writer.println("      </Item>");
                    x += 16;
                }
            }
            y -= 16;
        }

        // end of underworld brick blocks

        // underworld floor

        x = 6000;
        while (x < 6270) {
            writer.println("      <Item>");
            writer.println("        <name>UnderworldFloorBlock</name>");
            writer.println("        <PosX>" + x + "</PosX>");
            writer.println("        <PosY>464</PosY>");
            writer.println("      </Item>");
            x += 16;
        }
        x = 6000;
        while (x < 6270) {
            writer.println("      <Item>");
            writer.println("        <name>UnderworldFloorBlock</name>");
            writer.println("        <PosX>" + x + "</PosX>");
            writer.println("        <PosY>480</PosY>");
            writer.println("      </Item>");
            x += 16;
        }
        // end of underworld floor

        writer.println("    </blocks>");
    }

    private static void printEnemies(PrintWriter writer) {
        writer.println("    <enemies>");

        writer.println("      <Item>");
        writer.println("        <name>Goomba</name>");
        writer.println("        <PosX>352</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Goomba</name>");
        writer.println("        <PosX>640</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Goomba</name>");
        writer.println("        <PosX>816</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Goomba</name>");
        writer.println("        <PosX>840</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Goomba</name>");
        writer.println("        <PosX>1280</PosX>");
        writer.println("        <PosY>320</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Goomba</name>");
        writer.println("        <PosX>1312</PosX>");
        writer.println("        <PosY>320</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Goomba</name>");
        writer.println("        <PosX>1552</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Goomba</name>");
        writer.println("        <PosX>1576</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Koopa</name>");
        writer.println("        <PosX>1712</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Goomba</name>");
        writer.println("        <PosX>1824</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Goomba</name>");
        writer.println("        <PosX>1848</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Goomba</name>");
        writer.println("        <PosX>1984</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Goomba</name>");
        writer.println("        <PosX>2008</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Goomba</name>");
        writer.println("        <PosX>2048</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Goomba</name>");
        writer.println("        <PosX>2072</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Goomba</name>");
        writer.println("        <PosX>2784</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Goomba</name>");
        writer.println("        <PosX>2808</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("    </enemies>");
    }

    private static void printItems(PrintWriter writer) {
        writer.println("    <items>");

        writer.println("      <Item>");
        writer.println("        <name>Coin</name>");
        writer.println("        <PosX>1504</PosX>");
        writer.println("        <PosY>384</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>FireFlower</name>");
        writer.println("        <PosX>1248</PosX>");
        writer.println("        <PosY>384</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>FireFlower</name>");
        writer.println("        <PosX>1744</PosX>");
        writer.println("        <PosY>320</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Mushroom</name>");
        writer.println("        <PosX>336</PosX>");
        writer.println("        <PosY>384</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>PoisonMushroom</name>");
        writer.println("        <PosX>480</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("      </Item>");

        writer.println("      <Item>");
        writer.println("        <name>Star</name>");
        writer.println("        <PosX>1616</PosX>");
        writer.println("        <PosY>384</PosY>");
        writer.println("      </Item>");

        // coins in underworld
        int x;
        int y = 400;

        while (y > 360) {
            x = 6067;
            while (x < 6167) {
                writer.println("      <Item>");
                writer.println("        <name>Coin</name>");
                writer.println("        <PosX>" + x + "</PosX>");
                writer.println("        <PosY>" + y + "</PosY>");
                writer.println("      </Item>");
                x += 16;
            }

            y -= 32;
        }

        y = 336;
        x = 6083;

        while (x < 6150) {
            writer.println("      <Item>");
            writer.println("        <name>Coin</name>");
            writer.println("        <PosX>" + x + "</PosX>");
            writer.println("        <PosY>" + y + "</PosY>");
            writer.println("      </Item>");
            x += 16;
        }

        // end of coins in underworld

        writer.println("    </items>");
    }

    private static void printPipes(PrintWriter writer) {
        writer.println("    <pipes>");

        // short
        writer.println("      <Item>");
        writer.println("        <name>Pipe1</name>");
        writer.println("        <PosX>448</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("        <ID>1</ID>");
        writer.println("        <HasDestination>false</HasDestination>");
        writer.println("        <DestinationX>0</DestinationX>");
        writer.println("        <DestinationY>0</DestinationY>");
        writer.println("      </Item>");

        // medium
        writer.println("      <Item>");
        writer.println("        <name>Pipe2</name>");
        writer.println("        <PosX>608</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("        <ID>2</ID>");
        writer.println("        <HasDestination>false</HasDestination>");
        writer.println("        <DestinationX>0</DestinationX>");
        writer.println("        <DestinationY>0</DestinationY>");
        writer.println("      </Item>");

        // tall
        writer.println("      <Item>");
        writer.println("        <name>Pipe3</name>");
        writer.println("        <PosX>736</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("        <ID>3</ID>");
        writer.println("        <HasDestination>false</HasDestination>");
        writer.println("        <DestinationX>0</DestinationX>");
        writer.println("        <DestinationY>0</DestinationY>");
        writer.println("      </Item>");

        // tall
        writer.println("      <Item>");
        writer.println("        <name>Pipe3</name>");
        writer.println("        <PosX>912</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("        <ID>4</ID>");
        writer.println("        <HasDestination>true</HasDestination>");
        writer.println("        <DestinationX>6026</DestinationX>");
        writer.println("        <DestinationY>304</DestinationY>");
        writer.println("      </Item>");

        // short
        writer.println("      <Item>");
        writer.println("        <name>Pipe1</name>");
        writer.println("        <PosX>2608</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("        <ID>4</ID>");
        writer.println("        <HasDestination>false</HasDestination>");
        writer.println("        <DestinationX>0</DestinationX>");
        writer.println("        <DestinationY>0</DestinationY>");
        writer.println("      </Item>");

        // short
        writer.println("      <Item>");
        writer.println("        <name>Pipe1</name>");
        writer.println("        <PosX>2864</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("        <ID>5</ID>");
        writer.println("        <HasDestination>false</HasDestination>");
        writer.println("        <DestinationX>0</DestinationX>");
        writer.println("        <DestinationY>0</DestinationY>");
        writer.println("      </Item>");

        //
        writer.println("      <Item>");
        writer.println("        <name>Pipe5</name>");
        writer.println("        <PosX>6242</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("        <ID>6</ID>");
        writer.println("        <HasDestination>false</HasDestination>");
        writer.println("        <DestinationX>0</DestinationX>");
        writer.println("        <DestinationY>0</DestinationY>");
        writer.println("      </Item>");

        // sideways pipe
        writer.println("      <Item>");
        writer.println("        <name>Pipe4</name>");
        writer.println("        <PosX>6208</PosX>");
        writer.println("        <PosY>448</PosY>");
        writer.println("        <ID>7</ID>");
        writer.println("        <HasDestination>true</HasDestination>");
        writer.println("        <DestinationX>2620</DestinationX>");
        writer.println("        <DestinationY>416</DestinationY>");
        writer.println("      </Item>");

        writer.println("    </pipes>");
    }

    private static void printFlagPole(PrintWriter writer) {
        writer.println("    <flagpole>");

        // short
        writer.println("      <Item>");
        writer.println("        <name>Flagpole</name>");
        writer.println("        <PosX>3172</PosX>");
        writer.println("        <PosY>432</PosY>");
        writer.println("      </Item>");

        writer.println("    </flagpole>");
    }

    private static void printPlayers(PrintWriter writer) {
        writer.println("    <players>");

        writer.println("      <Item>");
        writer.println("        <name>Mario</name>");
        writer.println("        <PosX>42</PosX>");
        writer.println("        <PosY>449</PosY>");
        writer.println("      </Item>");

        writer.println("    </players>");
    }

}
