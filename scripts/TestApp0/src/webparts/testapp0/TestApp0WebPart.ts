import { Version } from '@microsoft/sp-core-library';
import { BaseClientSideWebPart } from '@microsoft/sp-webpart-base';

import styles from './TestApp0WebPart.module.scss';

export interface ITestApp0WebPartProps {
}

export default class TestApp0WebPart extends BaseClientSideWebPart<ITestApp0WebPartProps> {

  public render(): void {
    this.domElement.innerHTML = `<div class="${styles.testapp0}"></div>`;
  }

  protected onInit(): Promise<void> {
    return super.onInit();
  }

  protected get dataVersion(): Version {
    return Version.parse('1.0');
  }

}
