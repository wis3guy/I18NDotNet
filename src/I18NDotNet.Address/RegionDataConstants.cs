﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace I18N.Address
{
	public static class RegionDataConstants
	{
		private static readonly IDictionary<string, string> Constants;

		static RegionDataConstants()
		{
			Constants = new Dictionary<string, string>
			{
				{"AC", "{\"name\":\"ASCENSION ISLAND\"}"},
				{"AD", "{\"name\":\"ANDORRA\",\"lang\":\"ca\",\"languages\":\"ca\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"AE", "{\"name\":\"UNITED ARAB EMIRATES\",\"lang\":\"ar\",\"languages\":\"ar\",\"lfmt\":\"%N%n%O%n%A%n%S\",\"fmt\":\"%N%n%O%n%A%n%S\",\"require\":\"AS\",\"state_name_type\":\"emirate\"}"},
				{"AF", "{\"name\":\"AFGHANISTAN\"}"},
				{"AG", "{\"name\":\"ANTIGUA AND BARBUDA\",\"require\":\"A\"}"},
				{"AI", "{\"name\":\"ANGUILLA\"}"},
				{"AL", "{\"name\":\"ALBANIA\"}"},
				{"AM", "{\"name\":\"ARMENIA\",\"lang\":\"hy\",\"languages\":\"hy\",\"lfmt\":\"%N%n%O%n%A%n%Z%n%C%n%S\",\"fmt\":\"%N%n%O%n%A%n%Z%n%C%n%S\"}"},
				{"AO", "{\"name\":\"ANGOLA\"}"},
				{"AQ", "{\"name\":\"ANTARCTICA\"}"},
				{"AR", "{\"name\":\"ARGENTINA\",\"lang\":\"es\",\"languages\":\"es\",\"fmt\":\"%N%n%O%n%A%n%Z %C%n%S\",\"upper\":\"ACZ\"}"},
				{"AS", "{\"name\":\"AMERICAN SAMOA\",\"fmt\":\"%N%n%O%n%A%n%C %S %Z\",\"require\":\"ACSZ\",\"upper\":\"ACNOS\",\"state_name_type\":\"state\",\"zip_name_type\":\"zip\"}"},
				{"AT", "{\"name\":\"AUSTRIA\",\"fmt\":\"%O%n%N%n%A%n%Z %C\",\"require\":\"ACZ\"}"},
				{"AU", "{\"name\":\"AUSTRALIA\",\"lang\":\"en\",\"languages\":\"en\",\"fmt\":\"%O%n%N%n%A%n%C %S %Z\",\"require\":\"ACSZ\",\"upper\":\"CS\",\"state_name_type\":\"state\"}"},
				{"AW", "{\"name\":\"ARUBA\"}"},
				{"AX", "{\"name\":\"FINLAND\",\"fmt\":\"%O%n%N%n%A%nAX-%Z %C%nÅLAND\",\"require\":\"ACZ\",\"postprefix\":\"AX-\"}"},
				{"AZ", "{\"name\":\"AZERBAIJAN\",\"fmt\":\"%N%n%O%n%A%nAZ %Z %C\",\"postprefix\":\"AZ \"}"},
				{"BA", "{\"name\":\"BOSNIA AND HERZEGOVINA\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"BB", "{\"name\":\"BARBADOS\",\"state_name_type\":\"parish\"}"},
				{"BD", "{\"name\":\"BANGLADESH\",\"fmt\":\"%N%n%O%n%A%n%C - %Z\"}"},
				{"BE", "{\"name\":\"BELGIUM\",\"fmt\":\"%O%n%N%n%A%n%Z %C\",\"require\":\"ACZ\"}"},
				{"BF", "{\"name\":\"BURKINA FASO\",\"fmt\":\"%N%n%O%n%A%n%C %X\"}"},
				{"BG", "{\"name\":\"BULGARIA (REP.)\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"BH", "{\"name\":\"BAHRAIN\",\"fmt\":\"%N%n%O%n%A%n%C %Z\"}"},
				{"BI", "{\"name\":\"BURUNDI\"}"},
				{"BJ", "{\"name\":\"BENIN\",\"upper\":\"AC\"}"},
				{"BL", "{\"name\":\"SAINT BARTHELEMY\",\"fmt\":\"%O%n%N%n%A%n%Z %C %X\",\"require\":\"ACZ\",\"upper\":\"ACX\"}"},
				{"BM", "{\"name\":\"BERMUDA\",\"fmt\":\"%N%n%O%n%A%n%C %Z\"}"},
				{"BN", "{\"name\":\"BRUNEI DARUSSALAM\",\"fmt\":\"%N%n%O%n%A%n%C %Z\"}"},
				{"BO", "{\"name\":\"BOLIVIA\",\"upper\":\"AC\"}"},
				{"BQ", "{\"name\":\"BONAIRE, SINT EUSTATIUS, AND SABA\"}"},
				{"BR", "{\"name\":\"BRAZIL\",\"lang\":\"pt\",\"languages\":\"pt\",\"fmt\":\"%O%n%N%n%A%n%D%n%C-%S%n%Z\",\"require\":\"ASCZ\",\"upper\":\"CS\",\"sublocality_name_type\":\"neighborhood\",\"state_name_type\":\"state\",\"width_overrides\":\"%C:L%S:S\"}"},
				{"BS", "{\"name\":\"BAHAMAS\",\"lang\":\"en\",\"languages\":\"en\",\"fmt\":\"%N%n%O%n%A%n%C, %S\",\"state_name_type\":\"island\"}"},
				{"BT", "{\"name\":\"BHUTAN\"}"},
				{"BV", "{\"name\":\"BOUVET ISLAND\"}"},
				{"BW", "{\"name\":\"BOTSWANA\"}"},
				{"BY", "{\"name\":\"BELARUS\",\"fmt\":\"%S%n%Z %C %X%n%A%n%O%n%N\"}"},
				{"BZ", "{\"name\":\"BELIZE\"}"},
				{"CA", "{\"name\":\"CANADA\",\"lang\":\"en\",\"languages\":\"en~fr\",\"fmt\":\"%N%n%O%n%A%n%C %S %Z\",\"require\":\"ACSZ\",\"upper\":\"ACNOSZ\"}"},
				{"CC", "{\"name\":\"COCOS (KEELING) ISLANDS\",\"fmt\":\"%O%n%N%n%A%n%C %S %Z\",\"upper\":\"CS\"}"},
				{"CD", "{\"name\":\"CONGO (DEM. REP.)\",\"fmt\":\"%N%n%O%n%A%n%C %X\"}"},
				{"CF", "{\"name\":\"CENTRAL AFRICAN REPUBLIC\"}"},
				{"CG", "{\"name\":\"CONGO (REP.)\"}"},
				{"CH", "{\"name\":\"SWITZERLAND\",\"lang\":\"de\",\"languages\":\"de~fr~it\",\"fmt\":\"%O%n%N%n%A%nCH-%Z %C\",\"require\":\"ACZ\",\"upper\":\"\",\"postprefix\":\"CH-\"}"},
				{"CI", "{\"name\":\"COTE D'IVOIRE\",\"fmt\":\"%N%n%O%n%X %A %C %X\"}"},
				{"CK", "{\"name\":\"COOK ISLANDS\"}"},
				{"CL", "{\"name\":\"CHILE\",\"lang\":\"es\",\"languages\":\"es\",\"fmt\":\"%N%n%O%n%A%n%Z %C%n%D%n%S\"}"},
				{"CM", "{\"name\":\"CAMEROON\"}"},
				{"CN", "{\"name\":\"CHINA\",\"lang\":\"zh\",\"languages\":\"zh\",\"lfmt\":\"%N%n%O%n%A%n%D%n%C%n%S, %Z\",\"fmt\":\"%Z%n%S%C%D%n%A%n%O%n%N\",\"require\":\"ACSZ\",\"upper\":\"S\",\"sublocality_name_type\":\"district\",\"width_overrides\":\"%S:S%C:S%D:S\"}"},
				{"CO", "{\"name\":\"COLOMBIA\",\"fmt\":\"%N%n%O%n%A%n%C, %S, %Z\",\"require\":\"AS\",\"state_name_type\":\"department\"}"},
				{"CR", "{\"name\":\"COSTA RICA\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"CV", "{\"name\":\"CAPE VERDE\",\"lang\":\"pt\",\"languages\":\"pt\",\"fmt\":\"%N%n%O%n%A%n%Z %C%n%S\",\"state_name_type\":\"island\"}"},
				{"CW", "{\"name\":\"CURACAO\"}"},
				{"CX", "{\"name\":\"CHRISTMAS ISLAND\",\"fmt\":\"%O%n%N%n%A%n%C %S %Z\",\"upper\":\"CS\"}"},
				{"CY", "{\"name\":\"CYPRUS\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"CZ", "{\"name\":\"CZECH REP.\",\"fmt\":\"%N%n%O%n%A%n%Z %C\",\"width_overrides\":\"%SN:S%BI:S\"}"},
				{"DE", "{\"name\":\"GERMANY\",\"fmt\":\"%N%n%O%n%A%n%Z %C\",\"require\":\"ACZ\"}"},
				{"DJ", "{\"name\":\"DJIBOUTI\"}"},
				{"DK", "{\"name\":\"DENMARK\",\"fmt\":\"%N%n%O%n%A%n%Z %C\",\"require\":\"ACZ\"}"},
				{"DM", "{\"name\":\"DOMINICA\"}"},
				{"DO", "{\"name\":\"DOMINICAN REP.\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"DZ", "{\"name\":\"ALGERIA\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"EC", "{\"name\":\"ECUADOR\",\"fmt\":\"%N%n%O%n%A%n%Z%n%C\",\"upper\":\"CZ\"}"},
				{"EE", "{\"name\":\"ESTONIA\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"EG", "{\"name\":\"EGYPT\",\"lang\":\"ar\",\"languages\":\"ar\",\"lfmt\":\"%N%n%O%n%A%n%C%n%S%n%Z\",\"fmt\":\"%N%n%O%n%A%n%C%n%S%n%Z\"}"},
				{"EH", "{\"name\":\"WESTERN SAHARA\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"ER", "{\"name\":\"ERITREA\"}"},
				{"ES", "{\"name\":\"SPAIN\",\"lang\":\"es\",\"languages\":\"es\",\"fmt\":\"%N%n%O%n%A%n%Z %C %S\",\"require\":\"ACSZ\",\"upper\":\"CS\",\"width_overrides\":\"%S:S\"}"},
				{"ET", "{\"name\":\"ETHIOPIA\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"FI", "{\"name\":\"FINLAND\",\"fmt\":\"%O%n%N%n%A%nFI-%Z %C\",\"require\":\"ACZ\",\"postprefix\":\"FI-\"}"},
				{"FJ", "{\"name\":\"FIJI\"}"},
				{"FK", "{\"name\":\"FALKLAND ISLANDS (MALVINAS)\",\"fmt\":\"%N%n%O%n%A%n%X%n%C%n%Z\",\"require\":\"ACZ\",\"upper\":\"CZ\"}"},
				{"FM", "{\"name\":\"MICRONESIA (Federated State of)\",\"fmt\":\"%N%n%O%n%A%n%C %S %Z\",\"require\":\"ACSZ\",\"upper\":\"ACNOS\",\"state_name_type\":\"state\",\"zip_name_type\":\"zip\"}"},
				{"FO", "{\"name\":\"FAROE ISLANDS\",\"fmt\":\"%N%n%O%n%A%nFO%Z %C\",\"postprefix\":\"FO\"}"},
				{"FR", "{\"name\":\"FRANCE\",\"fmt\":\"%O%n%N%n%A%n%Z %C %X\",\"require\":\"ACZ\",\"upper\":\"CX\"}"},
				{"GA", "{\"name\":\"GABON\"}"},
				{"GB", "{\"name\":\"UNITED KINGDOM\",\"fmt\":\"%N%n%O%n%A%n%C%n%S%n%Z\",\"require\":\"ACZ\",\"upper\":\"CZ\",\"locality_name_type\":\"post_town\",\"state_name_type\":\"county\"}"},
				{"GD", "{\"name\":\"GRENADA (WEST INDIES)\"}"},
				{"GE", "{\"name\":\"GEORGIA\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"GF", "{\"name\":\"FRENCH GUIANA\",\"fmt\":\"%O%n%N%n%A%n%Z %C %X\",\"require\":\"ACZ\",\"upper\":\"ACX\"}"},
				{"GG", "{\"name\":\"CHANNEL ISLANDS\",\"fmt\":\"%N%n%O%n%A%n%X%n%C%nGUERNSEY%n%Z\",\"require\":\"ACZ\",\"upper\":\"CZ\"}"},
				{"GH", "{\"name\":\"GHANA\"}"},
				{"GI", "{\"name\":\"GIBRALTAR\",\"fmt\":\"%N%n%O%n%A%nGIBRALTAR%n%Z\",\"require\":\"A\"}"},
				{"GL", "{\"name\":\"GREENLAND\",\"fmt\":\"%N%n%O%n%A%n%Z %C\",\"require\":\"ACZ\"}"},
				{"GM", "{\"name\":\"GAMBIA\"}"},
				{"GN", "{\"name\":\"GUINEA\",\"fmt\":\"%N%n%O%n%Z %A %C\"}"},
				{"GP", "{\"name\":\"GUADELOUPE\",\"fmt\":\"%O%n%N%n%A%n%Z %C %X\",\"require\":\"ACZ\",\"upper\":\"ACX\"}"},
				{"GQ", "{\"name\":\"EQUATORIAL GUINEA\"}"},
				{"GR", "{\"name\":\"GREECE\",\"fmt\":\"%N%n%O%n%A%n%Z %C\",\"require\":\"ACZ\"}"},
				{"GS", "{\"name\":\"SOUTH GEORGIA\",\"fmt\":\"%N%n%O%n%A%n%X%n%C%n%Z\",\"require\":\"ACZ\",\"upper\":\"CZ\"}"},
				{"GT", "{\"name\":\"GUATEMALA\",\"fmt\":\"%N%n%O%n%A%n%Z- %C\"}"},
				{"GU", "{\"name\":\"GUAM\",\"fmt\":\"%N%n%O%n%A%n%C %S %Z\",\"require\":\"ACSZ\",\"upper\":\"ACNOS\",\"state_name_type\":\"state\",\"zip_name_type\":\"zip\"}"},
				{"GW", "{\"name\":\"GUINEA-BISSAU\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"GY", "{\"name\":\"GUYANA\"}"},
				{"HK", "{\"name\":\"HONG KONG\",\"lang\":\"zh-Hant\",\"languages\":\"zh-Hant~en\",\"lfmt\":\"%N%n%O%n%A%n%C%n%S\",\"fmt\":\"%S%n%C%n%A%n%O%n%N\",\"require\":\"AS\",\"upper\":\"S\",\"locality_name_type\":\"district\",\"state_name_type\":\"area\",\"width_overrides\":\"%S:S%C:L\"}"},
				{"HM", "{\"name\":\"HEARD AND MCDONALD ISLANDS\",\"fmt\":\"%O%n%N%n%A%n%C %S %Z\",\"upper\":\"CS\"}"},
				{"HN", "{\"name\":\"HONDURAS\",\"fmt\":\"%N%n%O%n%A%n%C, %S%n%Z\",\"require\":\"ACS\"}"},
				{"HR", "{\"name\":\"CROATIA\",\"fmt\":\"%N%n%O%n%A%nHR-%Z %C\",\"postprefix\":\"HR-\"}"},
				{"HT", "{\"name\":\"HAITI\",\"fmt\":\"%N%n%O%n%A%nHT%Z %C %X\",\"postprefix\":\"HT\"}"},
				{"HU", "{\"name\":\"HUNGARY (Rep.)\",\"fmt\":\"%N%n%O%n%C%n%A%n%Z\",\"require\":\"ACS\",\"upper\":\"ACNO\"}"},
				{"ID", "{\"name\":\"INDONESIA\",\"lang\":\"id\",\"languages\":\"id\",\"fmt\":\"%N%n%O%n%A%n%C%n%S %Z\",\"require\":\"AS\",\"width_overrides\":\"%BI:S%NH:N\"}"},
				{"IE", "{\"name\":\"IRELAND\",\"lang\":\"en\",\"languages\":\"en\",\"fmt\":\"%N%n%O%n%A%n%C%n%S\",\"state_name_type\":\"county\"}"},
				{"IL", "{\"name\":\"ISRAEL\",\"fmt\":\"%N%n%O%n%A%n%C %Z\"}"},
				{"IM", "{\"name\":\"ISLE OF MAN\",\"fmt\":\"%N%n%O%n%A%n%X%n%C%n%Z\",\"require\":\"ACZ\",\"upper\":\"CZ\"}"},
				{"IN", "{\"name\":\"INDIA\",\"lang\":\"en\",\"languages\":\"en\",\"fmt\":\"%N%n%O%n%A%n%C %Z%n%S\",\"require\":\"ACSZ\",\"state_name_type\":\"state\",\"zip_name_type\":\"pin\",\"width_overrides\":\"%NH:L\"}"},
				{"IO", "{\"name\":\"BRITISH INDIAN OCEAN TERRITORY\",\"fmt\":\"%N%n%O%n%A%n%X%n%C%n%Z\",\"require\":\"ACZ\",\"upper\":\"CZ\"}"},
				{"IQ", "{\"name\":\"IRAQ\",\"fmt\":\"%O%n%N%n%A%n%C, %S%n%Z\",\"require\":\"ACS\",\"upper\":\"CS\"}"},
				{"IR", "{\"name\":\"IRAN\",\"fmt\":\"%O%n%N%n%S%n%C, %D%n%A%n%Z\",\"sublocality_name_type\":\"neighborhood\"}"},
				{"IS", "{\"name\":\"ICELAND\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"IT", "{\"name\":\"ITALY\",\"lang\":\"it\",\"languages\":\"it\",\"fmt\":\"%N%n%O%n%A%n%Z %C %S\",\"require\":\"ACSZ\",\"upper\":\"CS\",\"width_overrides\":\"%S:S\"}"},
				{"JE", "{\"name\":\"CHANNEL ISLANDS\",\"fmt\":\"%N%n%O%n%A%n%X%n%C%nJERSEY%n%Z\",\"require\":\"ACZ\",\"upper\":\"CZ\"}"},
				{"JM", "{\"name\":\"JAMAICA\",\"lang\":\"en\",\"languages\":\"en\",\"fmt\":\"%N%n%O%n%A%n%C%n%S %X\",\"require\":\"ACS\",\"state_name_type\":\"parish\"}"},
				{"JO", "{\"name\":\"JORDAN\",\"fmt\":\"%N%n%O%n%A%n%C %Z\"}"},
				{"JP", "{\"name\":\"JAPAN\",\"lang\":\"ja\",\"languages\":\"ja\",\"lfmt\":\"%N%n%O%n%A%n%C, %S%n%Z\",\"fmt\":\"〒%Z%n%S%C%n%A%n%O%n%N\",\"require\":\"ACSZ\",\"upper\":\"S\",\"state_name_type\":\"prefecture\",\"width_overrides\":\"%S:S\"}"},
				{"KE", "{\"name\":\"KENYA\",\"fmt\":\"%N%n%O%n%A%n%C%n%Z\"}"},
				{"KG", "{\"name\":\"KYRGYZSTAN\",\"fmt\":\"%Z %C %X%n%A%n%O%n%N\"}"},
				{"KH", "{\"name\":\"CAMBODIA\",\"fmt\":\"%N%n%O%n%A%n%C %Z\"}"},
				{"KI", "{\"name\":\"KIRIBATI\",\"fmt\":\"%N%n%O%n%A%n%S%n%C\",\"upper\":\"ACNOS\",\"state_name_type\":\"island\"}"},
				{"KM", "{\"name\":\"COMOROS\",\"upper\":\"AC\"}"},
				{"KN", "{\"name\":\"SAINT KITTS AND NEVIS\",\"lang\":\"en\",\"languages\":\"en\",\"fmt\":\"%N%n%O%n%A%n%C, %S\",\"require\":\"ACS\",\"state_name_type\":\"island\"}"},
				{"KR", "{\"name\":\"SOUTH KOREA\",\"lang\":\"ko\",\"languages\":\"ko\",\"lfmt\":\"%N%n%O%n%A%n%D%n%C%n%S%n%Z\",\"fmt\":\"%S %C%D%n%A%n%O%n%N%n%Z\",\"require\":\"ACSZ\",\"upper\":\"Z\",\"sublocality_name_type\":\"district\",\"state_name_type\":\"do_si\"}"},
				{"KW", "{\"name\":\"KUWAIT\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"KY", "{\"name\":\"CAYMAN ISLANDS\",\"lang\":\"en\",\"languages\":\"en\",\"fmt\":\"%N%n%O%n%A%n%S %Z\",\"require\":\"AS\",\"state_name_type\":\"island\"}"},
				{"KZ", "{\"name\":\"KAZAKHSTAN\",\"fmt\":\"%Z%n%S%n%C%n%A%n%O%n%N\"}"},
				{"LA", "{\"name\":\"LAO (PEOPLE'S DEM. REP.)\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"LB", "{\"name\":\"LEBANON\",\"fmt\":\"%N%n%O%n%A%n%C %Z\"}"},
				{"LC", "{\"name\":\"SAINT LUCIA\"}"},
				{"LI", "{\"name\":\"LIECHTENSTEIN\",\"fmt\":\"%O%n%N%n%A%nFL-%Z %C\",\"require\":\"ACZ\",\"postprefix\":\"FL-\"}"},
				{"LK", "{\"name\":\"SRI LANKA\",\"fmt\":\"%N%n%O%n%A%n%C%n%Z\"}"},
				{"LR", "{\"name\":\"LIBERIA\",\"fmt\":\"%N%n%O%n%A%n%Z %C %X\"}"},
				{"LS", "{\"name\":\"LESOTHO\",\"fmt\":\"%N%n%O%n%A%n%C %Z\"}"},
				{"LT", "{\"name\":\"LITHUANIA\",\"fmt\":\"%O%n%N%n%A%nLT-%Z %C\",\"postprefix\":\"LT-\"}"},
				{"LU", "{\"name\":\"LUXEMBOURG\",\"fmt\":\"%O%n%N%n%A%nL-%Z %C\",\"require\":\"ACZ\",\"postprefix\":\"L-\"}"},
				{"LV", "{\"name\":\"LATVIA\",\"fmt\":\"%N%n%O%n%A%n%C, %Z\"}"},
				{"LY", "{\"name\":\"LIBYA\"}"},
				{"MA", "{\"name\":\"MOROCCO\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"MC", "{\"name\":\"MONACO\",\"fmt\":\"%N%n%O%n%A%nMC-%Z %C %X\",\"postprefix\":\"MC-\"}"},
				{"MD", "{\"name\":\"Rep. MOLDOVA\",\"fmt\":\"%N%n%O%n%A%nMD-%Z %C\",\"postprefix\":\"MD-\"}"},
				{"ME", "{\"name\":\"MONTENEGRO\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"MF", "{\"name\":\"SAINT MARTIN\",\"fmt\":\"%O%n%N%n%A%n%Z %C %X\",\"require\":\"ACZ\",\"upper\":\"ACX\"}"},
				{"MG", "{\"name\":\"MADAGASCAR\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"MH", "{\"name\":\"MARSHALL ISLANDS\",\"fmt\":\"%N%n%O%n%A%n%C %S %Z\",\"require\":\"ACSZ\",\"upper\":\"ACNOS\",\"state_name_type\":\"state\",\"zip_name_type\":\"zip\"}"},
				{"MK", "{\"name\":\"MACEDONIA\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"ML", "{\"name\":\"MALI\"}"},
				{"MM", "{\"name\":\"MYANMAR\",\"fmt\":\"%N%n%O%n%A%n%C, %Z\"}"},
				{"MN", "{\"name\":\"MONGOLIA\",\"fmt\":\"%N%n%O%n%A%n%S %C-%X%n%Z\"}"},
				{"MO", "{\"name\":\"MACAO\",\"lfmt\":\"%N%n%O%n%A\",\"fmt\":\"%A%n%O%n%N\",\"require\":\"A\"}"},
				{"MP", "{\"name\":\"NORTHERN MARIANA ISLANDS\",\"fmt\":\"%N%n%O%n%A%n%C %S %Z\",\"require\":\"ACSZ\",\"upper\":\"ACNOS\",\"state_name_type\":\"state\",\"zip_name_type\":\"zip\"}"},
				{"MQ", "{\"name\":\"MARTINIQUE\",\"fmt\":\"%O%n%N%n%A%n%Z %C %X\",\"require\":\"ACZ\",\"upper\":\"ACX\"}"},
				{"MR", "{\"name\":\"MAURITANIA\",\"upper\":\"AC\"}"},
				{"MS", "{\"name\":\"MONTSERRAT\"}"},
				{"MT", "{\"name\":\"MALTA\",\"fmt\":\"%N%n%O%n%A%n%C %Z\",\"upper\":\"CZ\"}"},
				{"MU", "{\"name\":\"MAURITIUS\",\"fmt\":\"%N%n%O%n%A%n%Z%n%C\",\"upper\":\"CZ\"}"},
				{"MV", "{\"name\":\"MALDIVES\",\"fmt\":\"%N%n%O%n%A%n%C %Z\"}"},
				{"MW", "{\"name\":\"MALAWI\",\"fmt\":\"%N%n%O%n%A%n%C %X\"}"},
				{"MX", "{\"name\":\"MEXICO\",\"lang\":\"es\",\"languages\":\"es\",\"fmt\":\"%N%n%O%n%A%n%D%n%Z %C, %S\",\"require\":\"ACZ\",\"upper\":\"CSZ\",\"sublocality_name_type\":\"neighborhood\",\"state_name_type\":\"state\",\"width_overrides\":\"%S:S%S2:N%S3:N%LP:N\"}"},
				{"MY", "{\"name\":\"MALAYSIA\",\"lang\":\"ms\",\"languages\":\"ms\",\"fmt\":\"%N%n%O%n%A%n%D%n%Z %C%n%S\",\"require\":\"ACZ\",\"upper\":\"CS\",\"sublocality_name_type\":\"village_township\",\"state_name_type\":\"state\"}"},
				{"MZ", "{\"name\":\"MOZAMBIQUE\"}"},
				{"NA", "{\"name\":\"NAMIBIA\"}"},
				{"NC", "{\"name\":\"NEW CALEDONIA\",\"fmt\":\"%O%n%N%n%A%n%Z %C %X\",\"require\":\"ACZ\",\"upper\":\"ACX\"}"},
				{"NE", "{\"name\":\"NIGER\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"NF", "{\"name\":\"NORFOLK ISLAND\",\"fmt\":\"%O%n%N%n%A%n%C %S %Z\",\"upper\":\"CS\"}"},
				{"NG", "{\"name\":\"NIGERIA\",\"lang\":\"en\",\"languages\":\"en\",\"fmt\":\"%N%n%O%n%A%n%C %Z%n%S\",\"upper\":\"CS\",\"state_name_type\":\"state\"}"},
				{"NI", "{\"name\":\"NICARAGUA\",\"lang\":\"es\",\"languages\":\"es\",\"fmt\":\"%N%n%O%n%A%n%Z%n%C, %S\",\"upper\":\"CS\",\"state_name_type\":\"department\"}"},
				{"NL", "{\"name\":\"NETHERLANDS\",\"fmt\":\"%O%n%N%n%A%n%Z %C\",\"require\":\"ACZ\"}"},
				{"NO", "{\"name\":\"NORWAY\",\"fmt\":\"%N%n%O%n%A%n%Z %C\",\"require\":\"ACZ\"}"},
				{"NP", "{\"name\":\"NEPAL\",\"fmt\":\"%N%n%O%n%A%n%C %Z\"}"},
				{"NR", "{\"name\":\"NAURU CENTRAL PACIFIC\",\"lang\":\"en\",\"languages\":\"en\",\"fmt\":\"%N%n%O%n%A%n%S\",\"require\":\"AS\",\"state_name_type\":\"district\"}"},
				{"NU", "{\"name\":\"NIUE\"}"},
				{"NZ", "{\"name\":\"NEW ZEALAND\",\"fmt\":\"%N%n%O%n%A%n%D%n%C %Z\",\"require\":\"ACZ\"}"},
				{"OM", "{\"name\":\"OMAN\",\"fmt\":\"%N%n%O%n%A%n%Z%n%C\"}"},
				{"PA", "{\"name\":\"PANAMA (REP.)\",\"fmt\":\"%N%n%O%n%A%n%C%n%S\",\"upper\":\"CS\"}"},
				{"PE", "{\"name\":\"PERU\"}"},
				{"PF", "{\"name\":\"FRENCH POLYNESIA\",\"fmt\":\"%N%n%O%n%A%n%Z %C %S\",\"require\":\"ACSZ\",\"upper\":\"CS\",\"state_name_type\":\"island\"}"},
				{"PG", "{\"name\":\"PAPUA NEW GUINEA\",\"fmt\":\"%N%n%O%n%A%n%C %Z %S\",\"require\":\"ACS\"}"},
				{"PH", "{\"name\":\"PHILIPPINES\",\"lang\":\"en\",\"languages\":\"en\",\"fmt\":\"%N%n%O%n%A%n%D, %C%n%Z %S\"}"},
				{"PK", "{\"name\":\"PAKISTAN\",\"fmt\":\"%N%n%O%n%A%n%C-%Z\"}"},
				{"PL", "{\"name\":\"POLAND\",\"fmt\":\"%N%n%O%n%A%n%Z %C\",\"require\":\"ACZ\"}"},
				{"PM", "{\"name\":\"ST. PIERRE AND MIQUELON\",\"fmt\":\"%O%n%N%n%A%n%Z %C %X\",\"require\":\"ACZ\",\"upper\":\"ACX\"}"},
				{"PN", "{\"name\":\"PITCAIRN\",\"fmt\":\"%N%n%O%n%A%n%X%n%C%n%Z\",\"require\":\"ACZ\",\"upper\":\"CZ\"}"},
				{"PR", "{\"name\":\"PUERTO RICO\",\"fmt\":\"%N%n%O%n%A%n%C PR %Z\",\"require\":\"ACZ\",\"upper\":\"ACNO\",\"zip_name_type\":\"zip\",\"postprefix\":\"PR\"}"},
				{"PS", "{\"name\":\"PALESTINIAN TERRITORY\"}"},
				{"PT", "{\"name\":\"PORTUGAL\",\"fmt\":\"%N%n%O%n%A%n%Z %C\",\"require\":\"ACZ\"}"},
				{"PW", "{\"name\":\"PALAU\",\"fmt\":\"%N%n%O%n%A%n%C %S %Z\",\"require\":\"ACSZ\",\"upper\":\"ACNOS\",\"state_name_type\":\"state\",\"zip_name_type\":\"zip\"}"},
				{"PY", "{\"name\":\"PARAGUAY\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"QA", "{\"name\":\"QATAR\",\"upper\":\"AC\"}"},
				{"RE", "{\"name\":\"REUNION\",\"fmt\":\"%O%n%N%n%A%n%Z %C %X\",\"require\":\"ACZ\",\"upper\":\"ACX\"}"},
				{"RO", "{\"name\":\"ROMANIA\",\"fmt\":\"%N%n%O%n%A%n%Z %C\",\"upper\":\"AC\"}"},
				{"RS", "{\"name\":\"REPUBLIC OF SERBIA\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"RU", "{\"name\":\"RUSSIAN FEDERATION\",\"lang\":\"ru\",\"languages\":\"ru\",\"lfmt\":\"%N%n%O%n%A%n%C%n%S%n%Z\",\"fmt\":\"%N%n%O%n%A%n%C%n%S%n%Z\",\"require\":\"ACZ\",\"upper\":\"AC\",\"state_name_type\":\"oblast\"}"},
				{"RW", "{\"name\":\"RWANDA\",\"upper\":\"AC\"}"},
				{"SA", "{\"name\":\"SAUDI ARABIA\",\"fmt\":\"%N%n%O%n%A%n%C %Z\"}"},
				{"SB", "{\"name\":\"SOLOMON ISLANDS\"}"},
				{"SC", "{\"name\":\"SEYCHELLES\",\"fmt\":\"%N%n%O%n%A%n%C%n%S\",\"upper\":\"S\",\"state_name_type\":\"island\"}"},
				{"SE", "{\"name\":\"SWEDEN\",\"fmt\":\"%O%n%N%n%A%nSE-%Z %C\",\"require\":\"ACZ\",\"postprefix\":\"SE-\"}"},
				{"SG", "{\"name\":\"REP. OF SINGAPORE\",\"fmt\":\"%N%n%O%n%A%nSINGAPORE %Z\",\"require\":\"AZ\"}"},
				{"SH", "{\"name\":\"SAINT HELENA\",\"fmt\":\"%N%n%O%n%A%n%X%n%C%n%Z\",\"require\":\"ACZ\",\"upper\":\"CZ\"}"},
				{"SI", "{\"name\":\"SLOVENIA\",\"fmt\":\"%N%n%O%n%A%nSI- %Z %C\",\"postprefix\":\"SI-\"}"},
				{"SJ", "{\"name\":\"SVALBARD AND JAN MAYEN ISLANDS\",\"fmt\":\"%N%n%O%n%A%n%Z %C\",\"require\":\"ACZ\"}"},
				{"SK", "{\"name\":\"SLOVAKIA\",\"fmt\":\"%N%n%O%n%A%n%Z %C\",\"width_overrides\":\"%SN:S%BI:S\"}"},
				{"SL", "{\"name\":\"SIERRA LEONE\"}"},
				{"SM", "{\"name\":\"SAN MARINO\",\"fmt\":\"%N%n%O%n%A%n%Z %C\",\"require\":\"AZ\"}"},
				{"SN", "{\"name\":\"SENEGAL\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"SO", "{\"name\":\"SOMALIA\",\"lang\":\"so\",\"languages\":\"so\",\"fmt\":\"%N%n%O%n%A%n%C, %S %Z\",\"require\":\"ACS\",\"upper\":\"ACS\"}"},
				{"SR", "{\"name\":\"SURINAME\",\"lang\":\"nl\",\"languages\":\"nl\",\"fmt\":\"%N%n%O%n%A%n%C %X%n%S\",\"upper\":\"AS\"}"},
				{"SS", "{\"name\":\"SOUTH SUDAN\"}"},
				{"ST", "{\"name\":\"SAO TOME AND PRINCIPE\",\"fmt\":\"%N%n%O%n%A%n%C %X\"}"},
				{"SV", "{\"name\":\"EL SALVADOR\",\"lang\":\"es\",\"languages\":\"es\",\"fmt\":\"%N%n%O%n%A%n%Z-%C%n%S\",\"require\":\"ACS\",\"upper\":\"CSZ\"}"},
				{"SX", "{\"name\":\"SINT MAARTEN\"}"},
				{"SZ", "{\"name\":\"SWAZILAND\",\"fmt\":\"%N%n%O%n%A%n%C%n%Z\",\"upper\":\"ACZ\"}"},
				{"TA", "{\"name\":\"TRISTAN DA CUNHA\"}"},
				{"TC", "{\"name\":\"TURKS AND CAICOS ISLANDS\",\"fmt\":\"%N%n%O%n%A%n%X%n%C%n%Z\",\"require\":\"ACZ\",\"upper\":\"CZ\"}"},
				{"TD", "{\"name\":\"CHAD\"}"},
				{"TF", "{\"name\":\"FRENCH SOUTHERN TERRITORIES\"}"},
				{"TG", "{\"name\":\"TOGO\"}"},
				{"TH", "{\"name\":\"THAILAND\",\"lang\":\"th\",\"languages\":\"th\",\"lfmt\":\"%N%n%O%n%A%n%D, %C%n%S %Z\",\"fmt\":\"%N%n%O%n%A%n%D %C%n%S %Z\",\"upper\":\"S\"}"},
				{"TJ", "{\"name\":\"TAJIKISTAN\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"TK", "{\"name\":\"TOKELAU\"}"},
				{"TL", "{\"name\":\"TIMOR-LESTE\"}"},
				{"TM", "{\"name\":\"TURKMENISTAN\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"TN", "{\"name\":\"TUNISIA\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"TO", "{\"name\":\"TONGA\"}"},
				{"TR", "{\"name\":\"TURKEY\",\"lang\":\"tr\",\"languages\":\"tr\",\"fmt\":\"%N%n%O%n%A%n%Z %C/%S\",\"require\":\"ACZ\",\"locality_name_type\":\"district\"}"},
				{"TT", "{\"name\":\"TRINIDAD AND TOBAGO\"}"},
				{"TV", "{\"name\":\"TUVALU\",\"lang\":\"tyv\",\"languages\":\"tyv\",\"fmt\":\"%N%n%O%n%A%n%X%n%C%n%S\",\"upper\":\"ACS\",\"state_name_type\":\"island\"}"},
				{"TW", "{\"name\":\"TAIWAN\",\"lang\":\"zh-Hant\",\"languages\":\"zh-Hant\",\"lfmt\":\"%N%n%O%n%A%n%C, %S %Z\",\"fmt\":\"%Z%n%S%C%n%A%n%O%n%N\",\"require\":\"ACSZ\",\"state_name_type\":\"county\"}"},
				{"TZ", "{\"name\":\"TANZANIA (UNITED REP.)\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"UA", "{\"name\":\"UKRAINE\",\"lang\":\"uk\",\"languages\":\"uk\",\"lfmt\":\"%N%n%O%n%A%n%C%n%S%n%Z\",\"fmt\":\"%N%n%O%n%A%n%C%n%S%n%Z\",\"require\":\"ACZ\",\"state_name_type\":\"oblast\"}"},
				{"UG", "{\"name\":\"UGANDA\"}"},
				{"UM", "{\"name\":\"UNITED STATES MINOR OUTLYING ISLANDS\",\"fmt\":\"%N%n%O%n%A%n%C %S %Z\",\"require\":\"ACS\",\"upper\":\"ACNOS\",\"state_name_type\":\"state\",\"zip_name_type\":\"zip\"}"},
				{"US", "{\"name\":\"UNITED STATES\",\"lang\":\"en\",\"languages\":\"en\",\"fmt\":\"%N%n%O%n%A%n%C, %S %Z\",\"require\":\"ACSZ\",\"upper\":\"CS\",\"state_name_type\":\"state\",\"zip_name_type\":\"zip\",\"width_overrides\":\"%S:S\"}"},
				{"UY", "{\"name\":\"URUGUAY\",\"lang\":\"es\",\"languages\":\"es\",\"fmt\":\"%N%n%O%n%A%n%Z %C %S\",\"upper\":\"CS\"}"},
				{"UZ", "{\"name\":\"UZBEKISTAN\",\"fmt\":\"%N%n%O%n%A%n%Z %C%n%S\",\"upper\":\"CS\"}"},
				{"VA", "{\"name\":\"VATICAN\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"VC", "{\"name\":\"SAINT VINCENT AND THE GRENADINES (ANTILLES)\"}"},
				{"VE", "{\"name\":\"VENEZUELA\",\"lang\":\"es\",\"languages\":\"es\",\"fmt\":\"%N%n%O%n%A%n%C %Z, %S\",\"require\":\"ACS\",\"upper\":\"CS\"}"},
				{"VG", "{\"name\":\"VIRGIN ISLANDS (BRITISH)\",\"fmt\":\"%N%n%O%n%A%n%C%n%Z\",\"require\":\"A\"}"},
				{"VI", "{\"name\":\"VIRGIN ISLANDS (U.S.)\",\"fmt\":\"%N%n%O%n%A%n%C %S %Z\",\"require\":\"ACSZ\",\"upper\":\"ACNOS\",\"state_name_type\":\"state\",\"zip_name_type\":\"zip\"}"},
				{"VN", "{\"name\":\"VIET NAM\",\"lang\":\"vi\",\"languages\":\"vi\",\"lfmt\":\"%N%n%O%n%A%n%C%n%S %Z\",\"fmt\":\"%N%n%O%n%A%n%C%n%S %Z\"}"},
				{"VU", "{\"name\":\"VANUATU\"}"},
				{"WF", "{\"name\":\"WALLIS AND FUTUNA ISLANDS\",\"fmt\":\"%O%n%N%n%A%n%Z %C %X\",\"require\":\"ACZ\",\"upper\":\"ACX\"}"},
				{"WS", "{\"name\":\"SAMOA\"}"},
				{"XK", "{\"name\":\"KOSOVO\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"YE", "{\"name\":\"YEMEN\"}"},
				{"YT", "{\"name\":\"MAYOTTE\",\"fmt\":\"%O%n%N%n%A%n%Z %C %X\",\"require\":\"ACZ\",\"upper\":\"ACX\"}"},
				{"ZA", "{\"name\":\"SOUTH AFRICA\",\"fmt\":\"%N%n%O%n%A%n%D%n%C%n%Z\",\"require\":\"ACZ\"}"},
				{"ZM", "{\"name\":\"ZAMBIA\",\"fmt\":\"%N%n%O%n%A%n%Z %C\"}"},
				{"ZW", "{\"name\":\"ZIMBABWE\"}"},
				{"ZZ", "{\"fmt\":\"%N%n%O%n%A%n%C\",\"require\":\"AC\",\"upper\":\"C\",\"sublocality_name_type\":\"suburb\",\"locality_name_type\":\"city\",\"state_name_type\":\"province\",\"zip_name_type\":\"postal\"}"}
			};
		}

		public static bool ContainsKey(string key) => Constants.ContainsKey(key);

		public static IDictionary<string, string> Get(string key) => JsonConvert.DeserializeObject<Dictionary<string, string>>(Constants[key]);
		
		public static IEnumerable<string> Keys => Constants.Keys;

		public const string DefaultCountryCode = "ZZ";
	}
}
