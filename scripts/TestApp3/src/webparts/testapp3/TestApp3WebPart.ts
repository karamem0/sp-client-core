import { Version } from '@microsoft/sp-core-library';
import { BaseClientSideWebPart } from '@microsoft/sp-webpart-base';

import styles from './TestApp3WebPart.module.scss';

export interface ITestApp3WebPartProps {
}

export default class TestApp3WebPart extends BaseClientSideWebPart<ITestApp3WebPartProps> {

  public render(): void {
    this.domElement.innerHTML = `<div class="${styles.testapp3}"></div>`;
  }

  protected onInit(): Promise<void> {
    return super.onInit();
  }

  protected get dataVersion(): Version {
    return Version.parse('1.0');
  }

}
