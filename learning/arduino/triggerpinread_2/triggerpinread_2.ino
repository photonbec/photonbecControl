#include <Arduino.h>

//https://forum.arduino.cc/index.php?topic=334073.0

void setup() {
  //pinMode(13, OUTPUT);
  for(int i = 0; i < 14; i++)
    pinMode(i, INPUT_PULLUP);
  Serial.begin(9600);
}

const int buffer_length = 256; //must be a power of two
int buf[buffer_length];
int i = 0;

void loop() {
  
  for(;;) {
    if(REG_PORT_IN0 & PORT_PA06) { //pin D8
    
      //for(int k = 0; k < buffer_length; k++) {
      //  buf[k] = REG_PORT_IN0;
      //}
      //*** loop unrolled below
      
      buf[0] = REG_PORT_IN0;
      buf[1] = REG_PORT_IN0;
      buf[2] = REG_PORT_IN0;
      buf[3] = REG_PORT_IN0;
      buf[4] = REG_PORT_IN0;
      buf[5] = REG_PORT_IN0;
      buf[6] = REG_PORT_IN0;
      buf[7] = REG_PORT_IN0;
      buf[8] = REG_PORT_IN0;
      buf[9] = REG_PORT_IN0;
      buf[10] = REG_PORT_IN0;
      buf[11] = REG_PORT_IN0;
      buf[12] = REG_PORT_IN0;
      buf[13] = REG_PORT_IN0;
      buf[14] = REG_PORT_IN0;
      buf[15] = REG_PORT_IN0;
      buf[16] = REG_PORT_IN0;
      buf[17] = REG_PORT_IN0;
      buf[18] = REG_PORT_IN0;
      buf[19] = REG_PORT_IN0;
      buf[20] = REG_PORT_IN0;
      buf[21] = REG_PORT_IN0;
      buf[22] = REG_PORT_IN0;
      buf[23] = REG_PORT_IN0;
      buf[24] = REG_PORT_IN0;
      buf[25] = REG_PORT_IN0;
      buf[26] = REG_PORT_IN0;
      buf[27] = REG_PORT_IN0;
      buf[28] = REG_PORT_IN0;
      buf[29] = REG_PORT_IN0;
      buf[30] = REG_PORT_IN0;
      buf[31] = REG_PORT_IN0;
      buf[32] = REG_PORT_IN0;
      buf[33] = REG_PORT_IN0;
      buf[34] = REG_PORT_IN0;
      buf[35] = REG_PORT_IN0;
      buf[36] = REG_PORT_IN0;
      buf[37] = REG_PORT_IN0;
      buf[38] = REG_PORT_IN0;
      buf[39] = REG_PORT_IN0;
      buf[40] = REG_PORT_IN0;
      buf[41] = REG_PORT_IN0;
      buf[42] = REG_PORT_IN0;
      buf[43] = REG_PORT_IN0;
      buf[44] = REG_PORT_IN0;
      buf[45] = REG_PORT_IN0;
      buf[46] = REG_PORT_IN0;
      buf[47] = REG_PORT_IN0;
      buf[48] = REG_PORT_IN0;
      buf[49] = REG_PORT_IN0;
      buf[50] = REG_PORT_IN0;
      buf[51] = REG_PORT_IN0;
      buf[52] = REG_PORT_IN0;
      buf[53] = REG_PORT_IN0;
      buf[54] = REG_PORT_IN0;
      buf[55] = REG_PORT_IN0;
      buf[56] = REG_PORT_IN0;
      buf[57] = REG_PORT_IN0;
      buf[58] = REG_PORT_IN0;
      buf[59] = REG_PORT_IN0;
      buf[60] = REG_PORT_IN0;
      buf[61] = REG_PORT_IN0;
      buf[62] = REG_PORT_IN0;
      buf[63] = REG_PORT_IN0;
      buf[64] = REG_PORT_IN0;
      buf[65] = REG_PORT_IN0;
      buf[66] = REG_PORT_IN0;
      buf[67] = REG_PORT_IN0;
      buf[68] = REG_PORT_IN0;
      buf[69] = REG_PORT_IN0;
      buf[70] = REG_PORT_IN0;
      buf[71] = REG_PORT_IN0;
      buf[72] = REG_PORT_IN0;
      buf[73] = REG_PORT_IN0;
      buf[74] = REG_PORT_IN0;
      buf[75] = REG_PORT_IN0;
      buf[76] = REG_PORT_IN0;
      buf[77] = REG_PORT_IN0;
      buf[78] = REG_PORT_IN0;
      buf[79] = REG_PORT_IN0;
      buf[80] = REG_PORT_IN0;
      buf[81] = REG_PORT_IN0;
      buf[82] = REG_PORT_IN0;
      buf[83] = REG_PORT_IN0;
      buf[84] = REG_PORT_IN0;
      buf[85] = REG_PORT_IN0;
      buf[86] = REG_PORT_IN0;
      buf[87] = REG_PORT_IN0;
      buf[88] = REG_PORT_IN0;
      buf[89] = REG_PORT_IN0;
      buf[90] = REG_PORT_IN0;
      buf[91] = REG_PORT_IN0;
      buf[92] = REG_PORT_IN0;
      buf[93] = REG_PORT_IN0;
      buf[94] = REG_PORT_IN0;
      buf[95] = REG_PORT_IN0;
      buf[96] = REG_PORT_IN0;
      buf[97] = REG_PORT_IN0;
      buf[98] = REG_PORT_IN0;
      buf[99] = REG_PORT_IN0;
      buf[100] = REG_PORT_IN0;
      buf[101] = REG_PORT_IN0;
      buf[102] = REG_PORT_IN0;
      buf[103] = REG_PORT_IN0;
      buf[104] = REG_PORT_IN0;
      buf[105] = REG_PORT_IN0;
      buf[106] = REG_PORT_IN0;
      buf[107] = REG_PORT_IN0;
      buf[108] = REG_PORT_IN0;
      buf[109] = REG_PORT_IN0;
      buf[110] = REG_PORT_IN0;
      buf[111] = REG_PORT_IN0;
      buf[112] = REG_PORT_IN0;
      buf[113] = REG_PORT_IN0;
      buf[114] = REG_PORT_IN0;
      buf[115] = REG_PORT_IN0;
      buf[116] = REG_PORT_IN0;
      buf[117] = REG_PORT_IN0;
      buf[118] = REG_PORT_IN0;
      buf[119] = REG_PORT_IN0;
      buf[120] = REG_PORT_IN0;
      buf[121] = REG_PORT_IN0;
      buf[122] = REG_PORT_IN0;
      buf[123] = REG_PORT_IN0;
      buf[124] = REG_PORT_IN0;
      buf[125] = REG_PORT_IN0;
      buf[126] = REG_PORT_IN0;
      buf[127] = REG_PORT_IN0;
      buf[128] = REG_PORT_IN0;
      buf[129] = REG_PORT_IN0;
      buf[130] = REG_PORT_IN0;
      buf[131] = REG_PORT_IN0;
      buf[132] = REG_PORT_IN0;
      buf[133] = REG_PORT_IN0;
      buf[134] = REG_PORT_IN0;
      buf[135] = REG_PORT_IN0;
      buf[136] = REG_PORT_IN0;
      buf[137] = REG_PORT_IN0;
      buf[138] = REG_PORT_IN0;
      buf[139] = REG_PORT_IN0;
      buf[140] = REG_PORT_IN0;
      buf[141] = REG_PORT_IN0;
      buf[142] = REG_PORT_IN0;
      buf[143] = REG_PORT_IN0;
      buf[144] = REG_PORT_IN0;
      buf[145] = REG_PORT_IN0;
      buf[146] = REG_PORT_IN0;
      buf[147] = REG_PORT_IN0;
      buf[148] = REG_PORT_IN0;
      buf[149] = REG_PORT_IN0;
      buf[150] = REG_PORT_IN0;
      buf[151] = REG_PORT_IN0;
      buf[152] = REG_PORT_IN0;
      buf[153] = REG_PORT_IN0;
      buf[154] = REG_PORT_IN0;
      buf[155] = REG_PORT_IN0;
      buf[156] = REG_PORT_IN0;
      buf[157] = REG_PORT_IN0;
      buf[158] = REG_PORT_IN0;
      buf[159] = REG_PORT_IN0;
      buf[160] = REG_PORT_IN0;
      buf[161] = REG_PORT_IN0;
      buf[162] = REG_PORT_IN0;
      buf[163] = REG_PORT_IN0;
      buf[164] = REG_PORT_IN0;
      buf[165] = REG_PORT_IN0;
      buf[166] = REG_PORT_IN0;
      buf[167] = REG_PORT_IN0;
      buf[168] = REG_PORT_IN0;
      buf[169] = REG_PORT_IN0;
      buf[170] = REG_PORT_IN0;
      buf[171] = REG_PORT_IN0;
      buf[172] = REG_PORT_IN0;
      buf[173] = REG_PORT_IN0;
      buf[174] = REG_PORT_IN0;
      buf[175] = REG_PORT_IN0;
      buf[176] = REG_PORT_IN0;
      buf[177] = REG_PORT_IN0;
      buf[178] = REG_PORT_IN0;
      buf[179] = REG_PORT_IN0;
      buf[180] = REG_PORT_IN0;
      buf[181] = REG_PORT_IN0;
      buf[182] = REG_PORT_IN0;
      buf[183] = REG_PORT_IN0;
      buf[184] = REG_PORT_IN0;
      buf[185] = REG_PORT_IN0;
      buf[186] = REG_PORT_IN0;
      buf[187] = REG_PORT_IN0;
      buf[188] = REG_PORT_IN0;
      buf[189] = REG_PORT_IN0;
      buf[190] = REG_PORT_IN0;
      buf[191] = REG_PORT_IN0;
      buf[192] = REG_PORT_IN0;
      buf[193] = REG_PORT_IN0;
      buf[194] = REG_PORT_IN0;
      buf[195] = REG_PORT_IN0;
      buf[196] = REG_PORT_IN0;
      buf[197] = REG_PORT_IN0;
      buf[198] = REG_PORT_IN0;
      buf[199] = REG_PORT_IN0;
      buf[200] = REG_PORT_IN0;
      buf[201] = REG_PORT_IN0;
      buf[202] = REG_PORT_IN0;
      buf[203] = REG_PORT_IN0;
      buf[204] = REG_PORT_IN0;
      buf[205] = REG_PORT_IN0;
      buf[206] = REG_PORT_IN0;
      buf[207] = REG_PORT_IN0;
      buf[208] = REG_PORT_IN0;
      buf[209] = REG_PORT_IN0;
      buf[210] = REG_PORT_IN0;
      buf[211] = REG_PORT_IN0;
      buf[212] = REG_PORT_IN0;
      buf[213] = REG_PORT_IN0;
      buf[214] = REG_PORT_IN0;
      buf[215] = REG_PORT_IN0;
      buf[216] = REG_PORT_IN0;
      buf[217] = REG_PORT_IN0;
      buf[218] = REG_PORT_IN0;
      buf[219] = REG_PORT_IN0;
      buf[220] = REG_PORT_IN0;
      buf[221] = REG_PORT_IN0;
      buf[222] = REG_PORT_IN0;
      buf[223] = REG_PORT_IN0;
      buf[224] = REG_PORT_IN0;
      buf[225] = REG_PORT_IN0;
      buf[226] = REG_PORT_IN0;
      buf[227] = REG_PORT_IN0;
      buf[228] = REG_PORT_IN0;
      buf[229] = REG_PORT_IN0;
      buf[230] = REG_PORT_IN0;
      buf[231] = REG_PORT_IN0;
      buf[232] = REG_PORT_IN0;
      buf[233] = REG_PORT_IN0;
      buf[234] = REG_PORT_IN0;
      buf[235] = REG_PORT_IN0;
      buf[236] = REG_PORT_IN0;
      buf[237] = REG_PORT_IN0;
      buf[238] = REG_PORT_IN0;
      buf[239] = REG_PORT_IN0;
      buf[240] = REG_PORT_IN0;
      buf[241] = REG_PORT_IN0;
      buf[242] = REG_PORT_IN0;
      buf[243] = REG_PORT_IN0;
      buf[244] = REG_PORT_IN0;
      buf[245] = REG_PORT_IN0;
      buf[246] = REG_PORT_IN0;
      buf[247] = REG_PORT_IN0;
      buf[248] = REG_PORT_IN0;
      buf[249] = REG_PORT_IN0;
      buf[250] = REG_PORT_IN0;
      buf[251] = REG_PORT_IN0;
      buf[252] = REG_PORT_IN0;
      buf[253] = REG_PORT_IN0;
      buf[254] = REG_PORT_IN0;
      buf[255] = REG_PORT_IN0;

      String s = String("o=");
      for(int k = 0; k < buffer_length; k++) {
        s += String((buf[k] >> 7) & 0x01, HEX); //pin D9
      }
      Serial.println(s);
    }
  }
}

