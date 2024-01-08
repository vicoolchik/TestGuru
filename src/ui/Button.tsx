import styled, { css } from "styled-components";

// Define TypeScript interfaces for props
interface SizeProps {
  small: ReturnType<typeof css>;
  medium: ReturnType<typeof css>;
  large: ReturnType<typeof css>;
}

interface VariationProps {
  primary: ReturnType<typeof css>;
  secondary: ReturnType<typeof css>;
  danger: ReturnType<typeof css>;
  linkLike: ReturnType<typeof css>;
}

interface ButtonProps {
  size: keyof SizeProps;
  variation: keyof VariationProps;
}

// Define your sizes and variations
const sizes: SizeProps = {
  small: css`
    font-size: 1.2rem;
    padding: 0.4rem 0.8rem;
    text-transform: uppercase;
    font-weight: 600;
    text-align: center;
  `,
  medium: css`
    font-size: 1.4rem;
    padding: 1.2rem 1.6rem;
    font-weight: 500;
  `,
  large: css`
    font-size: 1.6rem;
    padding: 1.2rem 2.4rem;
    font-weight: 500;
  `,
};

const variations: VariationProps = {
  primary: css`
    color: var(--color-brand-50);
    background-color: var(--color-brand-600);

    &:hover {
      background-color: var(--color-brand-700);
    }
  `,
  linkLike: css`
  text-align: center; 
  color: var(--color-grey-600);
  background: var(--color-grey-0);
  transition: all 0.3s;

  &:hover {
    color: var(--color-grey-800);
    background-color: var(--color-grey-100);
    border-radius: var(--border-radius-sm);
  }

  & > * { 
    display: inline-block; 
    vertical-align: middle;
    transition: all 0.3s;
  }

  & svg {
    width: 2.4rem;
    height: 2.4rem;
    margin-right: 8px;
    color: var(--color-grey-400);
  }

  &:hover svg {
    color: var(--color-brand-600);
  }`,
  secondary: css`
    color: var(--color-grey-600);
    background: var(--color-grey-0);
    border: 1px solid var(--color-grey-200);

    &:hover {
      background-color: var(--color-grey-50);
    }
  `,
  danger: css`
    color: var(--color-red-100);
    background-color: var(--color-red-700);

    &:hover {
      background-color: var(--color-red-800);
    }
  `,
};

// Update the Button styled component to use the ButtonProps interface
const Button = styled.button<ButtonProps>`
  border: none;
  border-radius: var(--border-radius-sm);

  ${(props) => sizes[props.size] || sizes.medium}
  ${(props) => variations[props.variation] || variations.primary}
`;

Button.defaultProps = {
  variation: "primary",
  size: "medium",
};

export default Button;
