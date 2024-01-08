import { useAuth0 } from "@auth0/auth0-react";
import styled from "styled-components";

const StyledUserAvatar = styled.div`
  display: flex;
  gap: 1.2rem;
  align-items: center;
  font-weight: 500;
  font-size: 1.4rem;
  color: var(--color-grey-600);
`;

const Avatar = styled.img`
  display: block;
  width: 4rem;
  width: 3.6rem;
  aspect-ratio: 1;
  object-fit: cover;
  object-position: center;
  border-radius: 50%;
  outline: 2px solid var(--color-grey-100);
`;

function UserAvatar() {
  const { isAuthenticated, user } = useAuth0();
  
  if (!user) {
    return null;
  }

  return (
    isAuthenticated && (<StyledUserAvatar>
      <Avatar
        src={user.picture} alt={user.name}
      />
      <span>{user.name}</span>
    </StyledUserAvatar>
  ));
}
export default UserAvatar;