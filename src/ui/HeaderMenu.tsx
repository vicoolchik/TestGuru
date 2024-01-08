import styled from "styled-components";
import DarkModeToggle from "./DarkModeToggle";
import { NavBarButtons } from "../components/nav-bar-buttons";

// Styled component
const StyledHeaderMenu = styled.ul`
  display: flex;
  gap: 0.4rem;
`;

// HeaderMenu component with TypeScript
const HeaderMenu: React.FC = () => {

  return (
    <StyledHeaderMenu>
      <li>
        <DarkModeToggle />
      </li>
      <NavBarButtons />
    </StyledHeaderMenu>
  );
}

export default HeaderMenu;
