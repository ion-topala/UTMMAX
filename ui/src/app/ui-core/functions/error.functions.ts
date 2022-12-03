export function hasCode(fullCode: string, code: string): boolean {
  const codeParts = getParts(fullCode);

  return codeParts.code === code;
}

interface ErrorCodeParts {
  area: string;
  action: string;
  code: string;
}

function getParts(fullCode: string): ErrorCodeParts {
  const parts = fullCode.split('.');

  return {
    area: parts[0],
    action: parts[1],
    code: parts[2],
  };
}
