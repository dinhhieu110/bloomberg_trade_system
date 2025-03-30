import { ChangeEvent, SyntheticEvent, useState } from "react";
import { CompanyCardList, FavoriteStockList, SearchBar } from "./components";
import { CompanySearch } from "./interfaces/company";
import { searchCompanies } from "./endpoints";

const App = () => {
  const [searchValue, setSearchValue] = useState<string>("");
  const [searchResult, setSearchResult] = useState<CompanySearch[]>([]);
  const [serverError, setSeverError] = useState<string>("");
  const [favoriteStocks, setFavoriteStocks] = useState<string[]>([]);
  console.log(searchValue);

  const handleSearch = (e: ChangeEvent<HTMLInputElement>) => {
    setSearchValue(e.target.value);
  };

  const onSearchSubmit = async (e: SyntheticEvent) => {
    e.preventDefault();
    const result = await searchCompanies(searchValue);
    if (typeof result === "string") {
      setSeverError(result);
    } else if (Array.isArray(result?.data)) {
      setSearchResult(result.data);
    }
    console.log(searchResult);
  };

  const onAddFavoriteStock = (e) => {
    e.preventDefault();
    console.log("e:", e);

    const isAddedFavoriteStock = favoriteStocks.find(
      (stock) => stock === e.target[0].value
    );
    console.log("isAddedFavoriteStock:", isAddedFavoriteStock);
    if (isAddedFavoriteStock) return;
    const updatedFavoriteStocks = [...favoriteStocks, e.target[0].value];
    setFavoriteStocks(updatedFavoriteStocks);
  };
  return (
    <div className="mx-5 md:mx-[6%]">
      <SearchBar
        onSearchSubmit={onSearchSubmit}
        searchValue={searchValue}
        handleSearch={handleSearch}
      />
      <FavoriteStockList favoriteStocks={favoriteStocks} />
      {serverError && <p>{serverError}</p>}
      <CompanyCardList
        searchResults={searchResult}
        onAddFavoriteStock={onAddFavoriteStock}
      />
    </div>
  );
};

export default App;
