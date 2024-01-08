import styled from "styled-components";

interface TagProps {
  type: 'primary' | 'secondary' | 'success' | 'danger'; 
}

const Tag = styled.span<TagProps>`
  width: fit-content;
  text-transform: uppercase;
  font-size: 1.1rem;
  font-weight: 600;
  padding: 0.4rem 1.2rem;
  border-radius: 100px;

  color: ${(props) => `var(--color-${props.type}-700)`};
  background-color: ${(props) => `var(--color-${props.type}-100)`};
`;

export default Tag;
