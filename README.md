# local-temperature-client

## 1. 기능
- 오늘 날짜 출력
- 현재 시간 출력
- 현재 기온 출력 (서울시 중구)

## 2. 웹서비스 예시

* URL

    http://apis.data.go.kr/1360000/VilageFcstInfoService/getUltraSrtNcst?serviceKey=F6hoThLUHh0%2B7nhIwFgvJAlKa1w4Qh2V5FssfvmDoz8zcJSUV1kgNcTmTHyg5wPUNTT7fPih7gzhiI3sXtYHBg%3D%3D&nx=60&ny=127&base_date=20210930&base_time=1500

* Result (XML)

<pre>
<code>
    <response>
    <header>
    <resultCode>00</resultCode>
    <resultMsg>NORMAL_SERVICE</resultMsg>
    </header>
    <body>
    <dataType>XML</dataType>
    <items>
    <item>
    <baseDate>20210930</baseDate>
    <baseTime>1500</baseTime>
    <category>PTY</category>
    <nx>60</nx>
    <ny>127</ny>
    <obsrValue>0</obsrValue>
    </item>
    <item>
    <baseDate>20210930</baseDate>
    <baseTime>1500</baseTime>
    <category>REH</category>
    <nx>60</nx>
    <ny>127</ny>
    <obsrValue>63</obsrValue>
    </item>
    <item>
    <baseDate>20210930</baseDate>
    <baseTime>1500</baseTime>
    <category>RN1</category>
    <nx>60</nx>
    <ny>127</ny>
    <obsrValue>0</obsrValue>
    </item>
    <item>
    <baseDate>20210930</baseDate>
    <baseTime>1500</baseTime>
    <category>T1H</category>
    <nx>60</nx>
    <ny>127</ny>
    <obsrValue>25.8</obsrValue>
    </item>
    <item>
    <baseDate>20210930</baseDate>
    <baseTime>1500</baseTime>
    <category>UUU</category>
    <nx>60</nx>
    <ny>127</ny>
    <obsrValue>1.8</obsrValue>
    </item>
    <item>
    <baseDate>20210930</baseDate>
    <baseTime>1500</baseTime>
    <category>VEC</category>
    <nx>60</nx>
    <ny>127</ny>
    <obsrValue>275</obsrValue>
    </item>
    <item>
    <baseDate>20210930</baseDate>
    <baseTime>1500</baseTime>
    <category>VVV</category>
    <nx>60</nx>
    <ny>127</ny>
    <obsrValue>-0.1</obsrValue>
    </item>
    <item>
    <baseDate>20210930</baseDate>
    <baseTime>1500</baseTime>
    <category>WSD</category>
    <nx>60</nx>
    <ny>127</ny>
    <obsrValue>1.8</obsrValue>
    </item>
    </items>
    <numOfRows>10</numOfRows>
    <pageNo>1</pageNo>
    <totalCount>8</totalCount>
    </body>
    </response>
    </code>
</pre>

## 3. 화면 예시

![제목 없음](https://user-images.githubusercontent.com/14077108/135241528-0a6cb4fd-b251-41e5-83be-411ebf5f9ccc.png)
