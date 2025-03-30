import { ChangeEvent, FC, JSX, SyntheticEvent, useState } from "react";

interface ISearchBarProps {
  searchValue: string | undefined;
  onSearchSubmit: (e: SyntheticEvent) => void;
  handleSearch: (e: ChangeEvent<HTMLInputElement>) => void;
}

const SearchBar: FC<ISearchBarProps> = (props): JSX.Element => {
  const { handleSearch, onSearchSubmit, searchValue } = props || {};
  return (
    <>
      <form onSubmit={onSearchSubmit}>
        <input className="border" value={searchValue} onChange={handleSearch} />
      </form>
    </>
  );
};
export default SearchBar;
