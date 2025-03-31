import React from "react";
import { Table } from "../components";
import RatioList from "../components/RatioList";

type Props = {};

const DesignGuide = (props: Props) => {
  return (
    <div>
      <h1>FinTech Design Page</h1>
      <h2>
        This is FinTech's design page. This is where we will design aspects of
        the app
      </h2>
      <RatioList />
      <Table />
      <h3>
        Table - Table takes in a configuration object and company data as
        params. Use config to style your table
      </h3>
    </div>
  );
};

export default DesignGuide;
