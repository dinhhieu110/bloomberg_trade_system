import React from "react";

type Props = {};

const TestDataCompany = [
  {
    symbol: "AAPL",
    price: 145.85,
    beta: 1.201965,
    volAvg: 79766736,
    mktCap: 2410929717248,
    lastDiv: 0.85,
    range: "105.0-157.26",
    changes: 2.4200134,
    companyName: "Apple Inc.",
    currency: "USD",
    cik: "0000320193",
    isin: "US0378331005",
    cusip: "037833100",
    exchange: "Nasdaq Global Select",
    exchangeShortName: "NASDAQ",
    industry: "Consumer Electronics",
    website: "http://www.apple.com",
    description:
      "Apple Inc. designs, manufactures, and markets smartphones, personal computers, tablets, wearables, and accessories worldwide. It also sells various related services. The company offers iPhone, a line of smartphones; Mac, a line of personal computers; iPad, a line of multi-purpose tablets; and wearables, home, and accessories comprising AirPods, Apple TV, Apple Watch, Beats products, HomePod, iPod touch, and other Apple-branded and third-party accessories. It also provides AppleCare support services; cloud services store services; and operates various platforms, including the App Store, that allow customers to discover and download applications and digital content, such as books, music, video, games, and podcasts. In addition, the company offers various services, such as Apple Arcade, a game subscription service; Apple Music, which offers users a curated listening experience with on-demand radio stations; Apple News+, a subscription news and magazine service; Apple TV+, which offers exclusive original content; Apple Card, a co-branded credit card; and Apple Pay, a cashless payment service, as well as licenses its intellectual property. The company serves consumers, and small and mid-sized businesses; and the education, enterprise, and government markets. It sells and delivers third-party applications for its products through the App Store. The company also sells its products through its retail and online stores, and direct sales force; and third-party cellular network carriers, wholesalers, retailers, and resellers. Apple Inc. was founded in 1977 and is headquartered in Cupertino, California.",
    ceo: "Mr. Timothy Cook",
    sector: "Technology",
    country: "US",
    fullTimeEmployees: "147000",
    phone: "14089961010",
    address: "1 Apple Park Way",
    city: "Cupertino",
    state: "CALIFORNIA",
    zip: "95014",
    dcfDiff: 89.92,
    dcf: 148.019,
    image: "https://financialmodelingprep.com/image-stock/AAPL.png",
    ipoDate: "1980-12-12",
    defaultImage: false,
    isEtf: false,
    isActivelyTrading: true,
    isAdr: false,
    isFund: false,
  },
];

const data = TestDataCompany[0];

type Company = typeof data;

const configs = [
  {
    label: "Date",
    render: (company: Company) => company.companyName,
    subTitle: "This is the company name",
  },
  {
    label: "Date",
    render: (company: Company) => company.companyName,
    subTitle: "This is the company name",
  },
  {
    label: "Date",
    render: (company: Company) => company.companyName,
    subTitle: "This is the company name",
  },
];

const RatioList = (props: Props) => {
  const renderedRow = configs.map((row) => (
    <li className="py-3 sm:py-4 ">
      <div className="flex item-center space-x-4">
        <div className="flex-1 min-w-0">
          <p className="text-sm font-medium text-gray-900 truncate">
            {row.label}
          </p>
          <p className="text-sm text-gray-500 truncate">
            {row.subTitle && row.subTitle}
          </p>
        </div>
        <div className="inline-flex items-center text-base font-semibold text-gray-900">
          {row.render(data)}
        </div>
      </div>
    </li>
  ));
  return (
    <div className="bg-white shadow rounded-lg mb-4 p-4 sm:p-6 h-full">
      <ul className="divide-y divided-gray-200">{renderedRow}</ul>
    </div>
  );
};

export default RatioList;
