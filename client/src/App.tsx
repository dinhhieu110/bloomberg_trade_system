import { ChangeEvent, SyntheticEvent, useState } from "react";
import { CardList, SearchBar } from "./components";
import { CompanySearch } from "./interfaces/company";
import { searchCompanies } from "./endpoints";

const App = () => {
  const [searchValue, setSearchValue] = useState<string>("");
  const [searchResult, setSearchResult] = useState<CompanySearch[]>([]);
  const [serverError, setSeverError] = useState<string>("");
  console.log(searchValue);

  const handleSearch = (e: ChangeEvent<HTMLInputElement>) => {
    setSearchValue(e.target.value);
  };

  const onClick = async (e: SyntheticEvent) => {
    e.preventDefault();
    const result = await searchCompanies(searchValue);
    if (typeof result === "string") {
      setSeverError(result);
    } else if (Array.isArray(result?.data)) {
      setSearchResult(result.data);
    }
    console.log(searchResult);
  };
  return (
    <div className="mx-5 md:mx-[6%]">
      <SearchBar
        onClick={onClick}
        searchValue={searchValue}
        handleSearch={handleSearch}
      />
      {serverError && <p>{serverError}</p>}
      <CardList searchResults={searchResult} />
    </div>
  );
};

export default App;
