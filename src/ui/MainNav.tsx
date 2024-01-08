import { useAuth0 } from '@auth0/auth0-react';
import { StyledNavLink } from './StyledNavLink'; // Adjust the import path as necessary
import {
  HiOutlineHome,
  HiOutlineUser,
  HiOutlinePlus,
  HiOutlineAcademicCap
} from "react-icons/hi2";
import styled from 'styled-components';
import UserAvatar from '../components/user-avatar';

const NavList = styled.ul`
  display: flex;
  flex-direction: column;
  gap: 0.8rem;
`;

function MainNav() {
  const { isAuthenticated } = useAuth0();
  return (
    <nav>
      <NavList>
        <li><StyledNavLink to="/dashboard"><HiOutlineHome /><span>Home</span></StyledNavLink></li>
        <li><StyledNavLink to="/newtest"><HiOutlinePlus /><span>New Test</span></StyledNavLink></li>
        <li><StyledNavLink to="/cabins"><HiOutlineAcademicCap /><span>Learn</span></StyledNavLink></li>
        {isAuthenticated ? (
          <li><StyledNavLink to="/users"><UserAvatar /></StyledNavLink></li>
        ) : (
          <li><StyledNavLink to="/users"><HiOutlineUser /><span>Profile</span></StyledNavLink></li>
        )}
        {/* <li><StyledNavLink to="/settings"><HiOutlineCog6Tooth /><span>Settings</span></StyledNavLink></li> */}
      </NavList>
    </nav>
  );
}

export default MainNav;
