import { PkuiPage } from './app.po';

describe('pkui App', function() {
  let page: PkuiPage;

  beforeEach(() => {
    page = new PkuiPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
