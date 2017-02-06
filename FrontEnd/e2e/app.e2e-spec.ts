import { QABagPage } from './app.po';

describe('qabag App', function() {
  let page: QABagPage;

  beforeEach(() => {
    page = new QABagPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
