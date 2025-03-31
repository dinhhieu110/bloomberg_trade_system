import { FC } from 'react';
import { ChangeEvent, SyntheticEvent, useState } from 'react';
import {
  CompanyCardList,
  FavoriteStockList,
  Navbar,
  SearchBar,
} from '../components';
import { searchCompanies } from '../endpoints';
import { CompanySearch } from '../interfaces/company';

interface ISearchPageProps {}

const SearchPage: FC<ISearchPageProps> = (props) => {
  const [searchValue, setSearchValue] = useState<string>('');
  const [searchResult, setSearchResult] = useState<CompanySearch[]>([]);
  const [serverError, setSeverError] = useState<string>('');
  const [favoriteStocks, setFavoriteStocks] = useState<string[]>([]);

  const handleSearch = (e: ChangeEvent<HTMLInputElement>) => {
    setSearchValue(e.target.value);
  };

  const onSearchSubmit = async (e: SyntheticEvent) => {
    e.preventDefault();
    const result = await searchCompanies(searchValue);
    if (typeof result === 'string') {
      setSeverError(result);
    } else if (Array.isArray(result?.data)) {
      setSearchResult(result.data);
    }
  };

  const onAddFavoriteStock = (e) => {
    e.preventDefault();

    const isAddedFavoriteStock = favoriteStocks.find(
      (stock) => stock === e.target[0].value
    );
    if (isAddedFavoriteStock) return;
    const updatedFavoriteStocks = [...favoriteStocks, e.target[0].value];
    setFavoriteStocks(updatedFavoriteStocks);
  };

  const onRemoveFavoriteStock = (e) => {
    e.preventDefault();

    const updatedFavoriteStocks = favoriteStocks.filter(
      (stock) => stock !== e.target[0].value
    );
    setFavoriteStocks(updatedFavoriteStocks);
  };

  return (
    <div>
      {/* <Hero /> */}
      <SearchBar
        onSearchSubmit={onSearchSubmit}
        searchValue={searchValue}
        handleSearch={handleSearch}
      />
      <FavoriteStockList
        favoriteStocks={favoriteStocks}
        onRemoveFavoriteStock={onRemoveFavoriteStock}
      />
      {serverError && <p>{serverError}</p>}
      <CompanyCardList
        searchResults={searchResult}
        onAddFavoriteStock={onAddFavoriteStock}
      />
    </div>
  );
};

export default SearchPage;
