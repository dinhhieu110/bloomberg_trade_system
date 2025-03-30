import { ChangeEvent, FC, JSX, SyntheticEvent, useState } from "react";

interface ISearchBarProps {
  searchValue: string | undefined;
  onClick: (e: SyntheticEvent) => void;
  handleSearch: (e: ChangeEvent<HTMLInputElement>) => void;
}

const SearchBar: FC<ISearchBarProps> = (props): JSX.Element => {
  const { handleSearch, onClick, searchValue } = props || {};
  return (
    <div>
      search bar
      <input onChange={handleSearch} type="text" value={searchValue} />
      <button onClick={onClick}>Click</button>
    </div>
  );
};

export default SearchBar;
