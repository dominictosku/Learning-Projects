// eslint.config.js
import globals from 'globals'
import pluginJs from '@eslint/js'

export default [
  {
    rules: {
      eqeqeq: ['error', 'always'],
      'prefer-const': 'error',
    },
    languageOptions: {
      globals: {
        ...globals.browser
      },
    },
  },
  pluginJs.configs.recommended,
]
